import os
import time
from fomatter import Formatter



def make_vdx():
	
	os.system('dot -Tvdx poll/out.txt > /media/sf_test-output/temp.vdx' )
	# tmeporary will be merged later
	#os.system('python formatter.py')


while(True):
	list = os.listdir('poll/')
	if 'out.txt' in list:
		make_vdx()
		print "found, making vdx"
		time.sleep(3)
		os.remove('poll/out.txt')
		os.remove('poll/dest.txt')
		os.remove('poll/nodeInfo.txt')
	else:
		print "not found, sleeping"
	time.sleep(3)
	
