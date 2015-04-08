from xml.dom.minidom import parse
import sys
filename = sys.argv[1]
DOM = parse(filename)
Shape = DOM.firstChild.getElementsByTagName("Shapes")[0].getElementsByTagName("Shape")[0]

Layout = DOM.createElement("Layout")

fixedCode = Layout.appendChild(DOM.createElement("ShapeFixedCode"))
fixedCode.appendChild(DOM.createTextNode("96"))
Shape.appendChild(Layout)
fp = open(filename,"w+")
fp.write(DOM.firstChild.toxml())
fp.close()
