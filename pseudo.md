1. Set of relationship **primitives**
	- primitive in `['B', 'Z', 'D', 'S', 'M', 'F', 'W', 'H']`

2. Relationship **node**, where each node has:
	- an **ego** boolean only settable on one node
	- four geometric **sides** in a `{top, right, bottom, left}` square
		- each side can be connected with an optional **tie**
			- connection **primitives** filled with primitive relations from ego node
				- formatted like `['MZD', ...]`
				- *problem*: storing (and changing) info about many other relationships in this node
				- *problem*: needing reciprocal definitions on the other side of the connecting node
				- *better*: figure out relationship given side, gender and marriage
			- **marriage** boolean settable in `left` and `right` but assumed false in `top` and `bottom`
				- redundant if `'W'` and `'H'` are included in primitives
				- `marriage = true` could allow for bottom ties in dynamic implementation of tree
			- simplified: just an array of primitives to connect from each side
	- a **gender** in `['d', 's']`

3. Relationship **tree**, where the tree places nodes in relation
	- *current* static tree
		- members populated by hand
		- each node bears internal label of relation from is
		- ego node can change properties (useful for e.g. gender in Hawaiian type)
	- built tree (*future build*)
		- horizontally symmetrical placement (if last node placed above left, do above right next)
		- relationship dynamically determined from active ego node
		- B/Z walk left or right and place node
		- M/F walk up and place node
		- S/D walk down and place node

4. Typed kinship **labels**
	- simple relation associates primitives from ego with typed labels
	- typed labels in 7 types (columns) stored in simple db
		- account for branching like Hawaiʻian-type brother/sister
	- labels for unique terms in a type are different
	- labels for shared terms in a type are the same
	- each label in `r'[A-Z]'`, where e.g. "Sudanese" requires more letters than "Hawaiian"

6. Surface kinship **terms** (*future build*)
	- relations associate type with terms in example languages within that type
		- how to handle branching like Hawaiʻian-type brother/sister?
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
