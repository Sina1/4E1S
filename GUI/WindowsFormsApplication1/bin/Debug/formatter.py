import os
import sys
import traceback
import json
import xml
from xml.dom.minidom import parseString

#os.system(' dot -Tvdx /media/sf_test-output/poll/out.txt > /media/sf_test-output/temp.vdx')


class Formatter():
        
        #config
        nameDiscriptionSepString = "\n\n\n\n\n"
        fontSize =  0.5/ 6      # for example, font size of 18 is 0.5/18
        
        #other 
        __MASTER_PATH = "sldSymbols/masters/new/"
        filename = ""
        inputVisioData = ""
        nodeInfoRaw = ""
        nodeTypeDict = {}
        nodeList = []
        nameDiscriptionSepString = "\n\n\n\n\n\n\n\n"
        __masterList = ['Bus', 'Capacitor', 'Generator', 'Motor', 'Negative_Load','Positive_Load', 'Transformer','Reactor' ,
        'New_Bus', 'New_Capacitor', 'New_Generator', 'New_Motor', 'New_Negative_Load','New_Positive_Load', 'New_Transformer','New_Reactor',
        'Removed_Bus', 'Removed_Capacitor', 'Removed_Generator', 'Removed_Motor', 'Removed_Negative_Load','Removed_Positive_Load', 'Removed_Transformer','Removed_Reactor',]
        masterIDDict = {'Bus'                                   : '50',
                                        'Capacitor'                             : '51',
                                        'Generator'                             : '52', 
                                        'Motor'                                 : '53', 
                                        'Negative_Load'                 : '54',
                                        'Positive_Load'                 : '55', 
                                        'Transformer'                   : '56',
                                        'Reactor'                               : '57',
                                        'New_Bus'                               : '70',
                                        'New_Capacitor'                 : '71',
                                        'New_Generator'                 : '72', 
                                        'New_Motor'                             : '73', 
                                        'New_Negative_Load'     : '74',
                                        'New_Positive_Load'     : '75', 
                                        'New_Transformer'               : '76',
                                        'New_Reactor'                   : '77',
                                        'Removed_Bus'                   : '90',
                                        'Removed_Capacitor'             : '91',
                                        'Removed_Generator'             : '92', 
                                        'Removed_Motor'                 : '93', 
                                        'Removed_Negative_Load' : '94',
                                        'Removed_Positive_Load' : '95', 
                                        'Removed_Transformer'   : '96',
                                        'Removed_Reactor'               : '97', 
                                        }
                                        
                                        
        def __init__(self,filename):
                self.filename = filename
                with open(filename, 'r') as infile:
                        self.inputVisioData = infile.read()
                        infile.close()
                        
                        
        # main function for this class
        def start(self, outFile):
                # load nodeTypeDict
                try:
                        with open('poll/nodeInfo.txt','r') as infile:
                                self.nodeInfoRaw = infile.read()
                                infile.close()
                        with open('poll/nodeList.txt','r') as infile:
                                self.nodeList = json.loads(infile.read())
                                infile.close()
                except Exception, e:
                        print str(e)
                        return -1
                
                # load node info from json file
                self.nodeTypeDict = json.loads(self.nodeInfoRaw)
                print (self.nodeTypeDict)
                masterString = self.loadMasters(self.__MASTER_PATH)
                
                
                # load visio rawData into xml 
                #mainXMLobj = XMLmanip(self.inputVisioData)
                mainXMLobj = XMLmanip(filename=self.filename)

                
                # load master String into xml type
                masterXMLobj = XMLmanip(data=masterString)
                
                # make page sheet
                pageLayout = mainXMLobj.makePageLayout()
                
                # make styleSheets
                #styleSheets = mainXMLobj.makeStyleSheet()
                # format font
                #fontTags = self.makeFontTags(mainXMLobj)
                #insert font formatting into stylesheets
                #for item in fontTags:
                #       styleSheets.firstChild.appendChild(item)
                #print styleSheets.toxml()
        
        
                # make visio settings
                docSettingsNode = mainXMLobj.makeDocSetting()
                #print masterXMLobj.DOMTree.getElementsByTagName('Masters')[0]
                
                
                # splice the two xml objects
                mainXMLobj.prependNodeToMain(masterXMLobj.DOMTree.getElementsByTagName('Masters')[0])
                
                # add the pageSheet to the main page
                mainXMLobj.DOMTree.firstChild.getElementsByTagName('Pages')[0].getElementsByTagName('Page')[0].getElementsByTagName('PageSheet')[0].appendChild(pageLayout)
                
                # add styleSheets to the top of the file3
                #mainXMLobj.prependNodeToMain(styleSheets)
                
                # add the document settins to the to of the xml file
                mainXMLobj.prependNodeToMain(docSettingsNode)
                
                print (mainXMLobj.DOMTree.firstChild.childNodes)
                
                # insert master id to shapes, delete shape geom, insert right angle edges code, insert node name
                shapeList = mainXMLobj.getShapeList()
                mainXMLobj.renameFirstShapeID()
                for shape in shapeList:
                        # set starting ID to 0
                        #ID = 0

                        # insert right angle code to visio file
                        mainXMLobj.rightAngle(shape)
                        
                        # delete shape geom and make the shape size the same as the masters
                        mainXMLobj.deleteShapeGeom(shape)
                        mainXMLobj.deleteShapeSize(shape)

                        # get and set the shape names
                        shapeName = mainXMLobj.getShapeName(shape)

                        # continue if the shape is 1-D shape
                        if shapeName == None:
                                continue
                                # add ID to this shape
                                #shape.setAttribute("ID", str(ID))
                                #ID = ID + 1
                                
                        #print shape.toxml()
                                
                        # make shape type and status
                        symbolType = self.nodeTypeDict[shapeName].title()
                        symbolStatus = self.getNodeStatus(str(shapeName))
                        symbolType = self.makeSymbolStatusString(symbolStatus) + symbolType
                                
                        mainXMLobj.insertMasterIDtoShape(shape,self.masterIDDict[symbolType.title()])
                        
                        # insert the shape name and discription to the shape
                        node = self.getNodeFromNodeList(shapeName)
                        #continue if node does not exist
                        if node == None:
                                continue
                        mainXMLobj.insertNameDescription(shape, node['name'] + self.nameDiscriptionSepString + node['description'])
                        # chage the font of the text
                        char0 = mainXMLobj.makeChar("0",sizePT=str(self.fontSize))
                        shape.insertBefore(char0, shape.getElementsByTagName("Text")[0])

                        # delete shape type attribute
                        mainXMLobj.removeTypeAttrFromShape(shape)

                # insert proper shape ID
                shapeList = mainXMLobj.getShapeList()
                shapeIDcounter = 0
                for shape in shapeList:
                        # check if shape is 1D shape
                        try:
                                masterID = shape.attributes['Master']
                                master = mainXMLobj.getMasterXMLbyID(masterID)
                        except:
                                # if its 1D shape
                                master == None

                        # if this is a 1D shape, then it has no master. count the shapes in this shape and not its master's shape        
                        if master == None:
                                masterShape = shape
                                IDcount = mainXMLobj.getShapeIDcount(masterShape)
                                shapeIDcounter = shapeIDcounter + IDcount
                                #print shapeIDcounter
                                shape.setAttribute("ID", str(shapeIDcounter))
                                continue
                        # check if master has shapes or shape element

                        # TODO make this more general
                        masterShapes = master.getElementsByTagName("Shapes")
                        if masterShapes == []:
                                masterShapeList = masterShape.getElementsByTagName("Shape")
                        else:
                                masterShapeList = masterShapes[0].getElementsByTagName("Shape")
                        IDcount = 0
                        for item in masterShapeList :
                                IDcount = IDcount +  mainXMLobj.getShapeIDcount(masterShape)

                        shapeIDcounter = shapeIDcounter + IDcount
                        print shapeIDcounter
                        shape.setAttribute("ID", str(shapeIDcounter))
                        
                        
                # write xml to file
                fp = open(outFile,'w')
                fp.write(mainXMLobj.DOMTree.toxml())
                fp.close()
                return 1
                
        def getNodeStatus(self,name):
                for item in self.nodeList:
                        if item['name'] == name:
                                return item['status']
                        
        def makeSymbolStatusString(self,status):
                if status == '.':
                        return ""
                elif status == '+':
                        return "New_"
                elif status == '-':
                        return "Removed_"
                else:
                        return ""
        
        # function for loading the masters in a string
        def loadMasters(self,path):
                returnString = ""
                
                # TODO only laod the necessary masters
                #mastersToLoadSet = set(self.nodeTypeDict.values())
                for master in self.__masterList:
                        with open(path + master.title(),'r') as infile:
                                for line in infile:
                                        returnString = returnString + line
                #print returnString
                
                return "<Masters>\r\n" + returnString + "</Masters>\r\n"
                
                
        def getNodeFromNodeList(self,name):
                for item in self.nodeList:
                        if item['name'] == name:
                                return item
                return None
        
        # returns list of nodes to be inserted into a stylesheet
        def makeFontTags(self, mainXMLobj):
                char = mainXMLobj.makeChar('0' ,size = str(self.fontSize))
                return [char]

        
                
                
class XMLmanip():
        collection = ""
        DOMTree = ""
        def __init__(self,filename = None,data = None):
                if data != None:
                        self.DOMTree = xml.dom.minidom.parseString(data)
                elif filename != None:
                        self.DOMTree = xml.dom.minidom.parse(filename)
                else:
                        pass
                self.colection =  self.DOMTree.documentElement
                        #if collection.hasAttribute("shelf"):
                        #       print "Root element : %s" % collection.getAttribute("shelf")
                #print self.DOMTree
                pass
        
        def prependNodeToMain(self,master):
                # # get all child nodes
                # childNodes = self.DOMTree.firstChild.childNodes
                # # delete all child Nodes
                # for nodeOrg in childNodes:
                #       self.DOMTree.firstChild.removeChild(nodeOrg)
                # # add the first node
                # 
                # self.DOMTree.firstChild.appendChild(master)
                # # add the rest of the nodes
                # for node in childNodes:
                #       self.DOMTree.firstChild.appendChild(node)
                self.DOMTree.firstChild.insertBefore(master,self.DOMTree.firstChild.firstChild)
                
                
        def printDOM(self, child = None):
                if child !=  None:
                        print child.toxml()
                else:
                        print DOMTree.toxml()
                        
                        
        def appendToMain(self,DOMTree):
                DOMTree.firstchild
                        
                        
        def getShapeList(self):
                pages = self.DOMTree.firstChild.getElementsByTagName('Pages')[0]
                page = pages.getElementsByTagName('Page')[0]
                shapes = page.getElementsByTagName('Shapes')[0]
                shapeList = shapes.getElementsByTagName('Shape')
                return shapeList
                        
                        
        def getShapeName(self,shape):
                # TODO improve this because the postion of text node is not certian
                try:
                        text = shape.getElementsByTagName('Text')[0]
                except Exception,e:
                        #print "text not found"
                        #print shape.attributes
                        return None
                textData = text.childNodes[2].nodeValue
                        
                return textData.strip()
                
        def deleteShapeGeom(self,shape):
                shape.removeChild(shape.getElementsByTagName('Geom')[0])
        
        def renameFirstShapeID(self):
                # TODO FIX THIS
                #self.DOMTree.firstChild.getElementsByTagName('Pages')[0].getElementsByTagName('Page')[0].getElementsByTagName('Shapes')[0].getElementsByTagName('Shape')[0].setAttribute('ID',"1000")
                pass
                
        def deleteShapeSize(self,shape):
                xform = shape.getElementsByTagName('XForm')[0]
                xform.removeChild(xform.getElementsByTagName('Width')[0])
                xform.removeChild(xform.getElementsByTagName('Height')[0])
        
        def insertMasterIDtoShape(self,shape,IDval):
                shape.setAttribute('Master',str(IDval))
                
        def rightAngle(self,shape):
                childNodes = shape.getElementsByTagName('XForm1D')
                if len(childNodes) == 0:
                        return
                baseNode = shape.getElementsByTagName('Layout')[0].getElementsByTagName('ConLineRouteExt')[0]
                if baseNode.firstChild.nodeType == baseNode.TEXT_NODE:
                        baseNode.firstChild.replaceWholeText('1')
        
        def makeDocSetting(self):
                docSetingsNode = self.DOMTree.createElement('DocumentSettings')
                snapSettings = docSetingsNode.appendChild(self.DOMTree.createElement('SnapSettings'))
                snapSettings.appendChild(self.DOMTree.createTextNode('32'))
                return docSetingsNode

        def makeChar(self,IX ,sizePT = ""):
                char = self.DOMTree.createElement("Char")
                char.setAttribute("IX", IX)
                size = char.appendChild(self.DOMTree.createElement("Size"))
                size.setAttribute("Unit","PT")
                size.appendChild(self.DOMTree.createTextNode(str(sizePT)))
                #print str(sizePT)
                return char
                
                
        def makeStyleSheet(self):
                styleSheets = self.DOMTree.createElement('StyleSheets')
                styleSheet = styleSheets.appendChild(self.DOMTree.createElement('StyleSheet'))
                styleSheet.setAttribute('ID','10')
                #Char = styleSheet.appendChild(self.DOMTree.createElement('Char'))
                #ShapeFixedCode.appendChild(self.DOMTree.createTextNode('64'))
                return styleSheets
        
        
        def makePageLayout(self):
        
                layout = self.DOMTree.createElement('PageLayout')
                From = layout.appendChild(self.DOMTree.createElement('LineAdjustFrom'))
                From.appendChild(self.DOMTree.createTextNode('1'))
                To = layout.appendChild(self.DOMTree.createElement('LineAdjustTo'))
                To.appendChild(self.DOMTree.createTextNode('2'))
        
                return layout

        # TODO check for error in the shape node
        # TODO fix this to take more formatting data
        def insertNameDescription(self,shape,nameDescription):
                
                TextNodeList = shape.getElementsByTagName("Text")
                if TextNodeList == []:
                        textNode = shape.appendChild(self.DOMTree.createElement('Text'))
                        textNode.appendChild(self.DOMTree.createTextNode(nameDescription))
                else:
                        TextNode = TextNodeList[0]
                        newTextNode = self.DOMTree.createElement('Text')
                        newTextNode.appendChild(self.DOMTree.createTextNode(nameDescription))
                        shape.replaceChild(newTextNode, TextNode)
                return

        # TODO make this more elegent
        def getShapeIDcount(self,shape):
                ID = 1
                shapesList = shape.getElementsByTagName('Shapes')
                if shapesList == []:
                        return ID
                Shapes = shapesList[0]
                shapeList = Shapes.getElementsByTagName('Shape')
                if shapeList == []:
                        return ID
                for shape in shapeList:
                        ID = ID + self.getShapeIDcount(shape)
                print ID
                return ID
        

        def removeTypeAttrFromShape(self,shape):
                shape.removeAttribute("Type")

        def getMasterXMLbyID(self, ID):
                ID = str(ID)
                masters  = self.DOMTree.firstChild.getElementsByTagName("Masters")[0]
                for master in masters.getElementsByTagName("Master"):
                        print master
                        if master.attributes["ID"] == ID:
                                return master

                return None

        
                        
#F = Formatter('temp.py')
#if F.start() == -1:
#       print "formatting failed"

#f = Formatter('/media/sf_test-output/temp.vdx')








#f.start()




