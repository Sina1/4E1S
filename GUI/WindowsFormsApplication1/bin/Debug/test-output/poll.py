import os
import time
from formatter import Formatter



def make_vdx():
	
	os.popen('dot -Tvdx /media/sf_test-output/poll/out.txt > /media/sf_test-output/temp.vdx' )
	
	# tmeporary will be merged later
	time.sleep(2)
	os.system('python formatter.py')


while(True):
	try:
		list = os.listdir('poll/')
		if 'out.txt' in list:
			make_vdx()
			print "found, making vdx"
			time.sleep(5)
			os.remove('poll/out.txt')
			
			os.remove('poll/dest.txt')
			os.remove('poll/nodeInfo.txt')
			os.remove('poll/nodeList.txt')
		else:
			print "not found, sleeping"
		time.sleep(3)
	except:
		time.sleep(3)	
