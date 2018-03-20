# Task List

## background
- [X] create project outline
- [X] draft project README
- [X] draft TODO list

## basic presentation
- [X] create static handmade family tree visuals
	- [X] basic primitive nodes
	- [X] basic primitive ties
	- [X] upgrade ties to reflect custom spacing and relationships
- [ ] create better visuals
	- [ ] better sprites for nodes
		- [ ] different colors
		- [ ] different shapes
	- [ ] better sprites for ties
	- [ ] background
	- [ ] sprite animations for FSM transitions
- [ ] place text over nodes
	- [ ] place format text for displaying strings of primaries, e.g. `"MZ"` -> `mother's sister`
	- [ ] place text for seven types
	- [ ] place text for any labels
- [ ] create UI menu
	- [ ] display primary terms by default (compounds)
	- [ ] select a system (types)
	- [ ] select an example (labels)
	- [ ] display current system being viewed
	- [ ] display current language being viewed
- [ ] create start screen
	- [ ] sketch draft image
	- [ ] implement first draft start screen

## basic logic
- [ ] set state of each member node
	- [ ] pass that data on node creation
	- [ ] allow for resetting
	- [ ] how does node handle position and value if reset? entire tree resets?
- [ ] update member node text with current node data accounting for the three layers
	- [ ] the primary strings
	- [ ] the system-specific terms
	- [ ] the language-specific labels
- [ ] change member node based on state
	- [ ] FSM for handling state changes: node color
	- [ ] FSM for handling state changes: node shape
- [ ] relationship manager (or just all local to each node?)
	- [ ] handle overview of node relationships
	- [ ] handle changes impacting surrounding nodes
	- [ ] store and set node colors
		- [ ] unique terms or labels have different colors
		- [ ] same terms or labels share the same color
	- [ ] store and set node shapes
		- [ ] typically used to represent gender (of member not term) on charts
- [ ] data fetch and display
	- [ ] populate labeled kin with exact terms from an example language
	- [ ] display labels in presentation (below)

## basic data
- [ ] `system` relation associates system `id` with system `name` (like `"Sudanese"`)
- [ ] `term` relation associates compound types (distance from ego) with terms
	- [ ] seven sets of terms broadly representing seven different kinship terminology systems
	- [ ] each term in `r'[A-Z]'`, where e.g. "Sudanese" requires more letters than "Hawaiian"
		- [ ] start counting up from `"A"`
		- [ ] unique terms within a system are assigned different term strings for different compound types
		- [ ] shared terms within a system are assigned the same term strings for different compound types
	- [ ] account for branching logic, e.g. Hawaiʻian-system sibling terms are sensitive to ego's gender
- [ ] `label` relation associates terms with labels
	- [ ] decide: use one relation per system or share one among all languages?
	- [ ] `id` for the label
	- [ ] `term` for each system term
	- [ ] (`system_id` for a unique `system.id` if using a single relation here)
	- [ ] `label` for surface translation in a language
	- [ ] `language` for label of the language the term comes from

## testing
- [ ] set up tests

## beyond
- [ ] calculate and visualize dynamic ties
	- [ ] connections based on data in node edges
	- [ ] place elbow, horiz, vert, spouse ties correctly
	- [ ] craft visuals for elbow, horiz, vert, spouse tie pieces
- [ ] store data in each of node's four sides
	- [ ] decide to store either a single primary or a compound in each side
	- [ ] upgrade current nodes to handle setting this state
	- [ ] upgrade current nodes/tree to handle checking this state
- [ ] output data to browser
	- [ ] test interfacing from within app to client
	- [ ] output current system name
	- [ ] output types data
	- [ ] output current language name
	- [ ] output labels data
