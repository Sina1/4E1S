import xml.dom.minidom as  md

def print_node(root):
    if root.childNodes:
        for node in root.childNodes:
           if node.nodeType == node.ELEMENT_NODE:
               print node.tagName,"has value:",  node.nodeValue, "and is child of:", node.parentNode.tagName
               print_node(node)

dom = md.parse("temp.vdx")
root = dom.documentElement
print_node(root)
