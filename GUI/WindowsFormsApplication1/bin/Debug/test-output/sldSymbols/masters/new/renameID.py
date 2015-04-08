sList = {'Bus'					: '50',
					'Capacitor'				: '51',
					'Generator'				: '52', 
					'Motor'					: '53', 
					'Negative_Load' 		: '54',
					'Positive_Load' 		: '55', 
					'Transformer' 			: '56',
					'Reactor'				: '57',
					'New_Bus'				: '70',
					'New_Capacitor'			: '71',
					'New_Generator'			: '72', 
					'New_Motor'				: '73', 
					'New_Negative_Load' 	: '74',
					'New_Positive_Load' 	: '75', 
					'New_Transformer' 		: '76',
					'New_Reactor'			: '77',
					'Removed_Bus'			: '90',
					'Removed_Capacitor'		: '91',
					'Removed_Generator'		: '92', 
					'Removed_Motor'			: '93', 
					'Removed_Negative_Load' : '94',
					'Removed_Positive_Load' : '95', 
					'Removed_Transformer' 	: '96',
					'Removed_Reactor'		: '97',
					}

import os
import sys
for item in sList.keys():
	if not os.path.exists(item):
		print "not there ", item
from xml.dom.minidom import parse
for files in sList.keys():
	try:
		DOMTree = parse(files)
		DOMTree.firstChild.setAttribute('ID',sList[files])
		fp = open(files, 'w+')
		fp.write(DOMTree.firstChild.toxml())
		fp.close()
	except:
		print "error ", files
		sys.exit()	
