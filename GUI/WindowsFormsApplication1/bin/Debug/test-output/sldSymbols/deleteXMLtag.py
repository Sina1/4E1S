import sys
filename =sys.argv[0] 
fp = open(filename,'r')
newString = ""
read = fp.read()
read = read.replace("\n","")
while(True):
	try:
		start = read.index("<Pages>")
		stop = read.index("</Pages>") 
		print start, " " , stop	
		
		read = read[:start] + read[stop+8:]

	except:
		break


fp.close()
fp = open(filename, "w+")
fp.write(read)
fp.close()
