import os
import sys
filepath = sys.argv[1]

fp = open(filepath, "r")
read = fp.read()
start = read.index(" Name=")
name = "" 
for char in read[start+7:]:
	if char =='"':
		break
	else:
		name = name + char

print name
folder = ""
fp.close()
for item in filepath.split(os.sep)[:-1]:
	folder = folder +  item + '/'
filename = filepath.split(os.sep)[-1]
command = "mv " + filepath + " " + folder + name.replace(" ","_")
print command
os.system(command)	
