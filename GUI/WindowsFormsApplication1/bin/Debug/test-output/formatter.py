import os
import sys
import traceback
import json
import xml
from xml.dom.minidom import parseString

class Formatter():

	__MASTER_PATH = "/media/sf_test-output/sldSymbols/masters/new/"
	filename = ""
	inputVisioData = ""
	nodeInfoRaw = ""
	nodeTypeDict = {}
	__masterList = ['Bus', 'Capacitor', 'Generator', 'Motor', 'Negative_Load','Positive_Load', 'Power_Transformer','Reactor' ]
	masterIDDict = {'Bus'				: '50',
					'Capacitor'			: '51',
					'Generator'			: '52', 
					'Motor'				: '53', 
					'Negative_Load' 	: '54',
					'Positive_Load' 	: '55', 
					'Power_Transformer' : '56',
					'Reactor'			: '57',
					}
					
					
	def __init__(self,filename):
		self.filename = filename
		with open(filename, 'r') as infile:
			self.inputVisioData = infile.read()
			
			
	# main function for this class
	def start(self):
		# load nodeTypeDict
		try:
			with open('poll/nodeInfo.txt','r') as infile:
				self.nodeInfoRaw = infile.read()
		except Exception, e:
			print str(e)
			return -1
		
		# load node info from json file
		self.nodeTypeDict = json.loads(self.nodeInfoRaw)
		print self.nodeTypeDict
		masterString = self.loadMasters(self.__MASTER_PATH)
		
		
		# load visio rawData into xml 
		#mainXMLobj = XMLmanip(self.inputVisioData)
		mainXMLobj = XMLmanip(filename=self.filename)
		
		# load master String into xml type
		masterXMLobj = XMLmanip(data=masterString)
		
		# splice the two xml objects
		
		mainXMLobj.prependNodeToMain(masterXMLobj.DOMTree.firstChild)
		
		# insert master id to shapes
		shapeList = mainXMLobj.getShapeList()
		for shape in shapeList:
			mainXMLobj.deleteShapeGeom(shape)
			mainXMLobj.deleteShapeSize(shape)
			shapeName = mainXMLobj.getShapeName(shape)
			# continue if the shaoe is 1D
			if shapeName == -1:
				continue
			symbolType = self.nodeTypeDict[shapeName]
			mainXMLobj.insertMasterIDtoShape(shape,self.masterIDDict[symbolType.title()])
			
		#print mainXMLobj.DOMTree.toxml()
		# write to file
		fp = open('out.vdx','w+')
		fp.write(mainXMLobj.DOMTree.toxml())
		fp.close()
		return 1
		
		
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
			# 	print "Root element : %s" % collection.getAttribute("shelf")
		print self.DOMTree
		pass
	
	def prependNodeToMain(self,master):
		# get all child nodes
		childNodes = self.DOMTree.firstChild.childNodes
		# delete all child Nodes
		for node in childNodes:
			self.DOMTree.firstChild.removeChild(node)
		# add the first node
		
		self.DOMTree.firstChild.appendChild(master)
		# add the rest of the nodes
		for node in childNodes:
			self.DOMTree.firstChild.appendChild(node)
		
		
		
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
		# TODO improve this as the postion of text node is not certian
		try:
			text = shape.getElementsByTagName('Text')[0]
		except Exception,e:
			print "text not found"
			print shape.attributes
			return -1
		textData = text.childNodes[2].nodeValue
			
		return textData.strip()
		
	def deleteShapeGeom(self,shape):
		shape.removeChild(shape.getElementsByTagName('Geom')[0])
		
	def deleteShapeSize(self,shape):
		xform = shape.getElementsByTagName('XForm')[0]
		xform.removeChild(xform.getElementsByTagName('Width')[0])
		xform.removeChild(xform.getElementsByTagName('Height')[0])
	
	def insertMasterIDtoShape(self,shape,IDval):
		shape.setAttribute('Master',str(IDval))
		
#F = Formatter('temp.py')
#if F.start() == -1:
#	print "formatting failed"

f = Formatter('/media/sf_test-output/temp.vdx')








f.start()




