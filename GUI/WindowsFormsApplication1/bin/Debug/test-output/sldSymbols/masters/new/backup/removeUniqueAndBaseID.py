import sys
filename = sys.argv[1]
fp = open(filename,'w+')
inString = fp.read()
start = inString.index("UniqueID")
stop = inString.index("PatternFlag")
outString = inString[:start] + inString[stop:]

fp.write(outString)
