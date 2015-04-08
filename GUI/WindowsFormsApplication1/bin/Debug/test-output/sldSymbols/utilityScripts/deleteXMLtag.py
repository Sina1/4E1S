import sys
filename =sys.argv[1] 
tag = sys.argv[2]
tag = '<' + tag + '>'
fp = open(filename,'r')
newString = ""
read = fp.read()
read = read.replace("\n","")
while(True):
	try:
		start = read.index(tag)
		stop = read.index(tag.replace('<','</'))
 		print start, " " , stop
		read = read[:start] + read[stop+len(tag)+1:]
	except:
		break
fp.close()

fp = open(filename, "w+")
fp.write(read)
fp.close()
