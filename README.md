# Kinship Term Explorer TreeBuilder

This is a kinship terminology tree builder created in Unity that serves as a "backend" and data visualization for the [Kinship Term Explorer](https://github.com/Botmasher/kinship-explorer-app) app.

## Description

Anthropologists traditionally break kinship terms around the world into a handful of systems. Tree diagrams are the traditional way to compare those systems. This program builds a tree of family member "types" and carries data relating types to labels in various languages.

When it's passed a specific language, it updates the members on the tree with new states and label text based on the language's terms. Members with the same term have the same color even if their kin types are different, while different terms have different colors.

Clicking ego changes ego's marking (currently "you" can be switched between brother vs sister, i.e. a MS vs MD, but you cannot change age marking for younger vs older). This showcases systems that have terms marked relative to ego.

This Unity code does not classify languages into distinct kin term systems. It only reads terms in a chosen language and reacts. To see these terms classified into systems, check out the frontend app linked at the top.

## Getting started

### Running the project

The latest build lives in the frontend app linked above. To see the visualization combined with UI or to play around with the app, visit the [Kinship Term Explorer frontend](https://github.com/Botmasher/kinship-explorer-app).

To edit this visualization:
- get a local copy of this project (by cloning it or however you prefer)
- install a version of [Unity](https://store.unity.com) (developed with `2017.2.0`)
- open Unity
- open your local copy of this project in Unity

### Project structure

Once you have the project open, take a look. A rule of thumb if you're new to Unity: be cautious about editing, adding or deleting game assets outside of Unity. It's not hard to break project associations.

- (have the project open in Unity – instructions above)
- navigate through the project folders to start making changes to `Assets`
	- `_scripts` is where you can dig into the source code and tinker with how the program behaves
	- `_objects` contains the primitive family member prefab and its simple animations
	- `_mattex` houses the materials and textures applied to the family ties and the background plane
	- `_scenes` has only the one main scene, since there are no scene transitions
- game objects
	- the scene starts with a light, camera and background plane
	- manager empties run scripts for family tree setup and updates once game starts
	- camera is stationary, but with settings adjusted from default to fit and crop the visualized tree
	- tree ties and member objects are instantiated after the game starts
	-	if editing objects, check in the Inspector to ensure script variable slots aren't broken or empty
- play testing
	- set the game window to the output resolution
	- this resolution matches project build settings for the WebGL player
- optionally edit files outside of Unity
	- add your own JavaScript messaging functions to `./Assets/plugins/ClientMessaging`
		- these methods are made available to call from the C# scripts in `_scripts/`
	- add or edit language terms in the JSON data at `./Assets/Resources/_data/terms.json`

## Source code

This visualization was developed with Unity version `2017.2.0`. The core project behaviors are found under `./Assets/_scripts`. The kinship labels are stored per language in a JSON object within `/Assets/Resources/_data`.

The game builds a static tree of family members, parses the JSON data, colors and labels family member objects based on data, and updates the members based on user interactions.

## Feature Branches

The `master` branch currently stores the production build running inside the live frontend. It houses the terms data internally, parses the JSON and updates the visualization based on the language name passed into `NodesManager`.

Work has begun on an `external-terms-data` branch. This code will strip out reliance on internal terms data, await passed-in terms from an external app, update the tree based on those terms and respond with critical state pieces relevant to external access (things like EGO marking to allow for age terms). The same or other state pieces will also need to be messaged back to external on visualization state changes unless branching based on family member state is to happen entirely within the game logic.

## Contributing

Both this visualization and the accompanying [frontend app](https://github.com/Botmasher/kinship-explorer-app) were built as a leadup to another project on kin terms, so they probably won't be under active development long after that one goes live. That said, if you try the project out and spot ways to fix it, submit an issue or a pull request. It's definitely appreciated if you document reproducible steps for any fixes or as much relevant context as you can for any upgrades.
