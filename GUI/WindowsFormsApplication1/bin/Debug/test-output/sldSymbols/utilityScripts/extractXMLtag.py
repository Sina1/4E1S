import sys
filename = sys.argv[1]
outFolder = sys.argv[2]
fp = open(filename,'r')
newString = ""
read = fp.read()
read = read.replace("\n","")
outlist = []
nameList = []
while(True):
	try:
		start = read.index("<Master ")
		stop = read.index("</Master>") 
		print start, " " , stop	
		master = read[start:stop+9]
		outlist.append(master)
		read = read[stop+9:]
		
		#startName = master.index("Name=")
        	#Ename = ""
        	#for char in master[startName+6:]:
               # 	if char =='"':
               #  	       break
               # 	else:
               #         	name = name + char
	#	nameList.append(name)
	except Exception, e:
		print e
		break
#print nameList

fp.close()
for item in outlist:
	fp = open(outFolder + '/master' + str(outlist.index(item)), "w+")

	fp.write(item)
	fp.close()
