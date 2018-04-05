import React, { Component } from 'react';
import GameMenu from './GameMenu';
import { GameContainer } from './GameContainer';
//import { systemsData } from './data';

// TODO load systems setup data as separate module
	// - include description of each system in data
	// - restructure state
	/*
		{
			systems: {
				'system_id': {
					name: '',
					languages: [],
					description: ''
				},
				...
				'system_id': {
					name: '',
					languages: [],
					description: ''
				}
			}
		}
	*/
	// - flip through descriptions as each system is selected
	// - just pick one canonical example (systems.sysName.languages[0]) for now

class App extends Component {
	constructor(props) {
		super(props);
		this.state = {
			currentSystem: 'global',
			currentLanguage: 'Primary',
			systems: {
				'global': {
					name: '(Global Types)',
					languages: ['Primary'],
					description: 'A kinship system based on you having all the kin in the ship.'
				},
				'inuit': {
					name: 'Inuit',
					languages: ['English', 'Iñupiaq'],
					description: 'Another kinship system but your lineal is not your collateral.'
				},
				'hawaiian': {
					name: 'Hawaiʻian',
					languages: ['Hawaiian'],
					description: 'A kinship system where you mark generations, sibling sameness and sibling age.'
				},
				'sudanese': {
					name: 'Sudanese',
					languages: ['Latin'],
					description: 'This is the kinship system for telling the difference between every single kin relation.'
				},
				'iroquois': {
					name: 'Iroquois',
					languages: ['Yanomamö', 'Navajo'],
					description: 'Ever needed to tell your parallel cousins apart from your cross? These are the kin terms for you.'
				},
				'crow': {
					name: 'Crow',
					languages: ['Akan'],
					description: 'One of two kinship terminology systems that skews Iroquois. Like Omaha but flipped!'
				},
				'omaha': {
					name: 'Omaha',
					languages: ['Igbo', 'Dani'],
					description: 'A kinship system that works like a skewed Iroquois. Like Crow but flipped!'
				}
			}
		};
	}

	// TODO rework this function for updating selected language (not used in demo but handy in future)
	handleUpdateTreeLabels = (systemName, languageName) => {
		window.gameInstance && window.gameInstance.SendMessage('Nodes Manager', 'LabelFamilyMembers', languageName);
		this.setState({currentSystem: systemName, currentLanguage: languageName});
	};

	// TODO check if gameInstance loading complete before setting ui or passing data
	handleUpdateSystem = systemName => {
		this.setState({currentSystem: systemName, currentLanguage: 'Primary'}, () => (
			window.gameInstance && (
				window.gameInstance.SendMessage('Nodes Manager', 'LabelFamilyMembers', this.state.systems[systemName].languages[0])
			)
		));
	};

	setFullscreen = () => window.gameInstance.SetFullscreen(1);

	render() {
		const { systems, currentSystem, currentLanguage } = this.state;
		return (
			<div className="App">
				<h1 className="app-title">
					<span className="letter-decoration">K</span>inship <span className="letter-decoration">T</span>erm <span className="letter-decoration">E</span>xplorer
				</h1>
				<GameMenu
					handleUpdateTreeLabels={this.handleUpdateTreeLabels}
					handleUpdateSystem={this.handleUpdateSystem}
					systems={Object.keys(systems).reduce((systemNameMaps, systemId) => [
						...systemNameMaps,
						{ id: systemId, name: systems[systemId].name }
					], [])}
					currentSystemId={currentSystem}
					currentLanguage={currentLanguage}
					currentDescription={systems[currentSystem].description}
				/>
				<GameContainer
					title={"Kinship Term Explorer"}
					setFullscreen={this.setFullscreen}
				/>
			</div>
		);
	}
}

export default App;
