import os
for i in range(0,21):
	fp = open("master" + str(i), "r")
	read = fp.read()
	start = read.index("Name=")
	name = "" 
	for char in read[start+6:]:
		if char =="'":
			break
		else:
			name = name + char

	print name
	command = "cp master" + str(i) + " new/" + name.replace(" ","_")
	print command
	os.system(command)	
