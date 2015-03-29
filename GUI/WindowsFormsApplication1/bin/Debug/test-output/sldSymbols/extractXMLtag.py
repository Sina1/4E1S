
fp = open('out','r')
newString = ""
read = fp.read()
read = read.replace("\n","")
outlist = []
while(True):
	try:
		start = read.index("<Master ")
		stop = read.index("</Master>") 
		print start, " " , stop	
		outlist.append(read[start:stop+9])
		read = read[:start] + read[stop+9:]

	except Exception, e:
		print e
		break


fp.close()
for item in outlist:
	fp = open("master" + str(outlist.index(item)), "w+")
	fp.write(item)
	fp.close()
