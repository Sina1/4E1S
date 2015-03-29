import sys
filename = sys.argv[1]
print filename
if raw_input("skip? y/n") == 'y':
	sys.exit()

fp = open(filename,'r')

newFile=""

for line in fp:
	if "v14:" in line or "vx:" in line:
		pass
	else:
		newFile = newFile + line 
fp.close()


fp = open(filename, 'w+')
fp.write(newFile)
fp.close() 







