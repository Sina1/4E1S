import sys
filename = sys.argv[1]
print filename
fp = open(filename,'r')
inString = fp.read()
start = inString.index("UniqueID")
stop = inString.index("PatternFlag")
outString = inString[:start] + inString[stop:]
fp.close()
fp = open(filename, 'w')
fp.write(outString)
