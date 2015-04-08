import sys
import os
import time
from xml.dom.minidom import parse


def prettyUp(filename):
        DOM = parse(filename)
        fp = open(filename,'w+')
        fp.write(DOM.firstChild.toprettyxml())
        fp.close()

def main():

	inFile = sys.argv[1]
	outFolder = sys.argv[2]
	
	try:
		os.mkdir(outFolder)
	except:
		print ("Unable to make folder " + outFolder + " . Exiting" )
		sys.exit()
	# extract the masters from the infile and put thiem in the outfolder
	time.sleep(0.1)
	print ("extracting master")
	os.system('python extractXMLtag.py ' + inFile + " " + outFolder)
	
	# remove the Icon tag, remove the uniqueID and remove the v14: tags
	fileList = os.listdir(outFolder)
	print (fileList)
	time.sleep(0.1)
	for files in fileList:
		print ("removing uniqueID")
		os.system('python removeUniqueAndBaseID.py ' + outFolder + '/' + files)
		time.sleep(1)
		prettyUp(outFolder + '/' + files)
		print ("deleting v14 tags")
		os.system('python deleteV14.py ' + outFolder + '/' + files)
		time.sleep(1)
		print ("deleting icon tag" )
		os.system('python deleteXMLtag.py ' + outFolder + '/' + files + " Icon")
		print ("rename file")
		os.system("python renameID.py " + outFolder + '/' + files)
main()
