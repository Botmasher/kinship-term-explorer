# Task List

## Background
- [X] create project outline
- [X] draft project README
- [X] draft TODO list

## Basics

### presentation
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

### logic
- [X] set state of each member node
	- [X] pass that data on node creation
	- [X] allow for resetting on user input
	- [X] how does node handle position and value if reset? entire tree resets?
		- [X] keep node in fixed position and constant compound primary value in this iteration
- [X] update member node text with current node text depending on typology
	- [X] just focus on the surface language-specific labels for this iteration
- [X] change member node based on state
	- [X] state update for handling changes to node color
	- [X] FSM for handling state changes to node shape (rotation)
- [ ] node relationship manager
	- [X] store node relationships
	- [X] handle calling nodes to set up and change state
	- [ ] handle changes impacting surrounding nodes
		- [ ] starter: if ego updates shape, sex-marked terms update as needed
		- [ ] if above, implement checking ego's state when populating data
	- [X] set node colors
		- [X] unique terms or labels have different colors
		- [X] same terms or labels share the same color
		- [X] keep logic to update color within individual member behavior
	- [X] set node shapes used to represent sex-marked terms on charts
		- [X] use rotation for this iteration
		- [X] keep function to toggle shape within individual member behavior 
- [X] data fetch and display
	- [X] populate labeled kin with exact terms from an example language
	- [X] display labels in the presentation
- [ ] get selected system from client
	- [ ] user selects a terminology system from menu
	- [ ] app sends selected language to node manager
	- [ ] node manager uses data

### JSON data
- [X] serialize JSON object
- [ ] combine terminology and label map
	- [ ] id is a compound string, like `"FZ"`
	- [ ] language name, like `"Tongan"`
	- [ ] compound string, like `"FZ"`
	- [ ] perhaps a "language" for displaying compounds, like `"Primary": {..., "father's sister", ...}`
	- [ ] consider special strings for cross-sibling terms, like `"Z_m"` vs `"Z_f"`
		- [ ] if implement this solution, parse these terms based on ego's property in branching program logic
	- [ ] consider special strings for older vs younger terms, like `"Z_older"` vs `"Z_younger"`
- [ ] associate languages with systems
	- [ ] language name, like `"Arabic"`
	- [ ] system name, like `"Sudanese"`

## Testing
- [ ] set up tests

## Beyond

### presentation and logic
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

### data tables
- [ ] `system` relation associates system `id` with system `name` (like `"Sudanese"`)
- [ ] `term` relation associates compound types (distance from ego) with terms
	- [ ] seven sets of terms broadly representing seven different kinship terminology systems
	- [ ] each term in `r'[A-Z]'`, where e.g. "Sudanese" requires more letters than "Hawaiian"
		- [ ] start counting up from `"A"`
		- [ ] unique terms within a system are assigned different term strings for different compound types
		- [ ] shared terms within a system are assigned the same term strings for different compound types
	- [ ] account for branching logic, e.g. Hawaiʻian-system sibling terms are sensitive to ego's gender
		- [ ] remove or revise the interim solution implemented with basic JSON deserialization above
- [ ] `label` relation associates terms with labels
	- [ ] decide: use one relation per system or share one among all languages?
	- [ ] `id` for the label
	- [ ] `term` for each system term
	- [ ] (`system_id` for a unique `system.id` if using a single relation here)
	- [ ] `label` for surface translation in a language
	- [ ] `language` for label of the language the term comes from
