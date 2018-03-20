## project flow
1. Set of relationship **primary types** (or "primaries")
	- primary in `['B', 'Z', 'D', 'S', 'M', 'F', 'W', 'H']`

2. Relationship **node**, where each node has:
	- an **ego** boolean
		- present on every node
		- can only equal `1` for one node at a time, otherwise `0`
	- a kinship **compound type** (or "compound")
		- a compound string of primaries representing relationship distance from ego
		- populated by hand for starters
		- TODO eventually populate dynamically based on connections from sides (below)
	- TODO four geometric **sides** in a `{top, right, bottom, left}` square
		- each side can be connected with an optional **relationship**
			- TODO side relations storage options:
				1. one array per side filled with all immediate primary relations, e.g. siblings
					- *problem*: storing (and changing) info about many other relationships in this node
					- *problem*: needing reciprocal definitions on the other side of the connecting node
					- *better*: figure out relationship given side, gender and marriage
				2. one string per side and chain search to determine all relationships from there
					- e.g. multiple siblings
						- ego has `'B'` to left and `'Z'` to right
						- `'Z'` to right also has another `'B'` to right
						- so `ego.right` points to sister, who points to brother
						- relationships calculated from there
	- a **marriage** boolean settable in `left` or `right` but assumed false in `top` and `bottom`
		- *redundant* if `'W'` and `'H'` are included in primitives
		- `marriage = true` could allow for bottom ties in dynamic implementation of tree
		- simplified: just an array of primitives to connect from each side
	- a **gender**, mostly also redundant
		- not redundant for ego

3. Relationship **tree**, where the tree places nodes in relation
	- *current* static tree
		- members populated by hand
		- each node bears internal string representing kinship **type** from ego
		- ego node can change properties (useful for e.g. gender in Hawaiian type)
	- TODO dynamic tree
		- horizontally symmetrical placement (if last node placed above left, do above right next)
		- relationship dynamically determined from active ego node
		- B/Z walk left or right and place node
		- M/F walk up and place node
		- S/D walk down and place node

4. Kinship **terms**
	- simple relation associates compound types (distance from ego) with kinship terms
		- seven sets of terms broadly representing seven different kinship terminology systems
	- terms in 7 (columns) stored in simple db
		- TODO account for branching logic, e.g. Hawaiʻian-system sibling terms are sensitive to ego's gender
	- each term in `r'[A-Z]'`, where e.g. "Sudanese" requires more letters than "Hawaiian"
		- start counting up from `"A"`
		- unique terms within a system are assigned different term strings for different compound types
		- shared terms within a system are assigned the same term strings for different compound types

6. Surface kinship **labels**
	- relations associate terms with labels in example languages within each system
		- one relation per system
		- `id` for the label
		- `term` for each system term
		- (`type` for compound type may be left out here)
		- `label` for surface translation in a language
		- `language` for label of the language the term comes from
	- populate labeled kin with exact terms from an example language
	- display labels in presentation (below)

5. Visual **presentation**
	- a geometric shape for each node
	- shape changes based on gender
	- color changes based on similarity of labels
		- labels that are +unique are different colors
		- labels that are -unique share the same color
	- connect ties above/below or to the sides of nodes (currently static)
	- place text over node
