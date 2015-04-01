##import os
import json
##
##config = {
##            'graphvizPath' : "F:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe",
##            'destPath'     : "",
##            'gveditPath'   : "F:\Program Files (x86)\Graphviz2.38\gvedit.exe",
##            'dotCommand'   : "dot -Tpng " 
##
##        }
##
##
##def main():
##    #define busses, . means black, + means green, - means red
##    #busList = [
##    #            {'name': 'bus1','description': '6kV','status': '.'},
##    #            {'name': 'bus2','description': '12kV','status': '.'},
##    #            {'name': 'bus3','description': '18kV','status': '.'},
##    #            {'name': 'bus4','description': '22kV','status': '.'},
##    #            {'name': 'bus5','description': '54kV','status': '.'},
##    #        ]
##    ## define the connections. '.' means black, + means green, - means read
##    #connectionList = [
##    #                {1 : 'bus1', 2 : 'bus2', 'status': '.'},
##    #                {1 : 'bus2', 2 : 'bus3', 'status': '.'},
##    #                {1 : 'bus1', 2 : 'bus3', 'status': '+'},
##    #                {1 : 'bus4', 2 : 'bus1', 'status': '+'},
##    #                {1 : 'bus5', 2 : 'bus1', 'status': '+'},
##    #                ]
##    # mkae graphviz string
##
##    #get json data and deserialize it
##
##    fp = open('jsonFile.txt')
##    for line in fp:
##        print (line)
##
##    fp.close()
##    fp = open('jsonFile.txt')
##    dataDict = json.loads(fp.read())
##    
##    # load data
##    busList = dataDict['busList']
##    connectionList = dataDict['connectionList']
##    config['destPath'] = dataDict['filepath']
##    
##    gString = make_graphviz_string(busList, connectionList)
##
##    # write gString to file for later use
##    text_file = open("temp.dot", "w")
##    text_file.write(gString)
##    text_file.close()
##    
##    command = '"' + config['graphvizPath'] + '" ' + config['dotCommand'] \
##              + "temp.dot > " + config['destPath'] + ".png" 
##    
##    print (gString)
##    print (command)
##    returnCode = os.system(command)
##    #os.remove("temp.dot")
##    print (returnCode)
##    
##def make_graphviz_string(busList,connectionList):
##
##    skipBus = True
##    skipConnection = True    
##
##    
##    if validateBusList(busList):
##        skipBus = False
##    if validateConnectionList(connectionList):
##        skipConnection = False
##
##    upperS = '''digraph G {
##            graph [splines=ortho, nodesep=8 ranksep=5 margin=1];
##            edge [arrowhead=none,arrowtail=none ];\n'''
##
##    middleS = "\t\t" + make_rank(busList)
##
##
##    if not skipBus:
##        for bus in busList:
##            middleS = middleS + make_bus(bus['name'], bus['description'])
##
##    if not skipConnection:    
##        for connection in connectionList:
##            middleS += make_connection(connection["1"],connection["2"])
##    
##
##
##    finalS = upperS + middleS + '\n}'
##    return finalS
##
##
##def make_bus(name, description):
##    busString = "\t\t" + name + '[shape=polygon sides=4 width=.1 image="shapes/bus.png "'
##    busString = busString + 'xlabel="' + description + '" fontsize=72 label="" '
##
##    busString = busString + '];\n';
##    
##    return busString
##
##def make_connection(bus1, bus2):
##    return "\t\t" + bus1 + ' -> ' + bus2 + ' [penwidth=3 shape=none ] ;\n'
##
##def make_rank(busList):
##    i = 0
##    s = ""
##    while (i < len(busList)):
##        s = s + "{ rank=same "
##        j=0
##        while (j<3 and i < len(busList)):
##            s = s + busList[i]['name'] + " "
##            j = j+1
##            i = i+1
##        s = s + ";}\n"
##        
##    return s 
##    
##def validateBusList(busList):
##    finalList = busList.copy()
##    for bus in busList:
##        if not bus['name'] == "":
##            continue
##        else:
##            finalList.remove(bus)
##    
##    if len(finalList) == 0:
##        return False
##    else:
##        return True
##
##def validateConnectionList(connectionList):
##    finalLst = connectionList.copy()
##    if not len(connectionList) == 0:
##        for connection in connectionList:
##            print (len(connection))
##            if len(connection) < 3:
##                finalList.remove(connectiom)
##                continue
##            
##            tempList = [connection["1"], connection["2"] ]
##            if not None in tempList or "" in tempList:
##                continue
##            else:
##                finalList.remove(connection)
##
##    if len(finalLst ) == 0:
##        return False
##    else:
##        return True
##
##
##
##
##main()
##


fp = open('jsonFile.txt')
dataDict = json.loads(fp.read())
print "nodes:"
for item in dataDict['busList']:
    print item
print "\nconnections:"
for item in dataDict['connectionList']:
    print item

input()
        
