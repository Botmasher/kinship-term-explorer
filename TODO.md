# Task List

## Background
- [X] create project outline
- [X] draft project README
- [X] draft TODO list

## Basics
- [X] separate out frontend TODOS and relocate to within the React project

### visuals
- [X] create better visuals
	- [X] better sprites for ties
	- [X] background
	- [X] label repopulate so at least Hawaiian type is not so jarring when switching "you"
- [X] place text over nodes
	- [X] place format text for displaying strings of primaries, e.g. `"MZ"` -> `mother's sister`
	- [X] place text for any kin term labels
- [X] break apart family member object
	- [X] parent empty for handling data display and presentation choice logic
	- [X] cube child object for coloring and rotation
	- [X] text mesh child object for displaying labels

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
- [X] node relationship manager
	- [X] store node relationships
	- [X] handle calling nodes to set up and change state
	- [X] handle ego marking impacting term choices for other nodes
		- [X] implement checking data for marked terms
		- [X] implement checking ego's state when populating data
		- [X] if ego updates shape, sex-marked terms update as needed
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
	- [X] user selects a terminology system from menu
	- [X] app sends selected language to node manager
	- [X] node manager uses data
	- [ ] verify that data exists for the language

### JSON data
- [X] serialize JSON object
- [X] combine terminology and label map
	- [X] id is a compound string, like `"FZ"`
	- [X] language name, like `"Tongan"`
	- [X] compound string, like `"FZ"`
	- [X] perhaps a "language" for displaying compounds, like `"Primary": {..., "father's sister", ...}`
	- [X] fill out data from representative languages
	- [X] arrange data to handle terms marked relative to state of ego
		- [X] f vs m terms, like `"Z": "F": {}` (sister term if EGO is F)
		- [X] implement by comparing data, member nodes and ego node when labeling in node manager
- [X] cite sources (for now to be handled in frontend)

## Testing
- [ ] set up tests

## Beyond

### feedback
- [ ] extend generations below ego, e.g. Dutch nephew/niece = cousin terms (https://www.patreon.com/posts/slapping-labels-17717106)
	- [ ] changes game logic and family tree builder
	- [ ] presentation asset needs for generating -1 and -2 ties / members
	- [ ] add data to every language in the JSON
	- [ ] figure out dynamic node placement to make generating trees like this flexible

### visualization and logic
- [ ] print text displaying "you" as older/younger brother/sister
- [ ] allow switching between toggling vs cycling ego marking
	- [ ] family member behavior logic
	- [ ] interface for user to hit switch
- [ ] create +1 generation spouse objects
- [ ] create extra older and younger sibling objects (tied to improving data and logic to handle age)
- [ ] calculate and visualize dynamic ties
	- [ ] connections based on data in node edges
	- [ ] place elbow, horiz, vert, spouse ties correctly
	- [ ] craft visuals for elbow, horiz, vert, spouse tie pieces
- [ ] store data in each of node's four sides
	- [ ] decide to store either a single primary or a compound in each side
	- [ ] upgrade current nodes to handle setting this state
	- [ ] upgrade current nodes/tree to handle checking this state
- [ ] output data to browser
	- [X] test interfacing from within app to client (see `ClientMessaging.jslib` plugin)
	- [ ] output current system name
	- [ ] output types data
	- [ ] output current language name
	- [ ] output labels data
- [ ] create better visuals
	- [ ] better sprites/shapes for nodes
	- [ ] refine colors for nodes
	- [ ] sprite animations for FSM transitions

### data
- [ ] add tasks here from the `external-terms-data` feature documentation in README
- [ ] ability to add notes to display next to data
	- [ ] example: Hawaiʻian terms given are basic but often "wahine" or "kāne" is tacked on
	- [ ] example: Hawaiʻian terms also distinguish sibling age
	- [ ] example: Akan sees Crow pattern upon father's passing
- [ ] improve current JSON models
	- [ ] older vs younger terms in a way akin to current marking
	- [ ] associate languages with systems
		- [ ] language name, like `"Arabic"`
		- [ ] system name, like `"Sudanese"`
- [ ] upgrade database
	- [ ] `system` relation associates system `id` with system `name` (like `"Sudanese"`)
	- [ ] `term` relation associates compound types (distance from ego) with terms
		- [ ] sets of terms broadly representing different kinship terminology systems
		- [ ] each term in `r'[A-Z]'`, where e.g. "Sudanese" requires more letters than "Hawaiian"
			- [ ] start counting up from `"A"`
			- [ ] unique terms within a system are assigned different term strings for different compound types
			- [ ] shared terms within a system are assigned the same term strings for different compound types
		- [ ] account for branching logic, e.g. Hawaiʻian-system sibling terms are sensitive to ego's marking
			- [ ] remove or revise the interim solution implemented with basic JSON deserialization above
	- [ ] `label` relation associates terms with labels
		- [ ] decide: use one relation per system or share one among all languages?
		- [ ] `id` for the label
		- [ ] `term` for each system term
		- [ ] (`system_id` for a unique `system.id` if using a single relation here)
		- [ ] `label` for surface translation in a language
		- [ ] `language` for label of the language the term comes from
