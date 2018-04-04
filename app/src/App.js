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
			currentSystem: '(Global Types)',
			currentLanguage: '',
			systems: {
				'Global Types': ['Primary'],
				'Inuit': ['English', 'Iñupiaq'],
				'Hawaiian': ['Hawaiian'],
				'Sudanese': ['Latin'],
				'Iroquois': ['Yanomamö', 'Navajo'],
				'Crow': ['Akan'],
				'Omaha': ['Igbo', 'Dani']
			}
		};
	}

	handleUpdateTreeLabels = (systemName, languageName) => {
		window.gameInstance && window.gameInstance.SendMessage('Nodes Manager', 'LabelFamilyMembers', languageName);
		this.setState({currentSystem: systemName, currentLanguage: languageName});
	};

	handleUpdateSystem = systemName => {
		window.gameInstance && window.gameInstance.SendMessage('Nodes Manager', 'LabelFamilyMembers', 'Primary');
		this.setState({currentSystem: systemName, currentLanguage: 'Primary'});
	};

	setFullscreen = () => window.gameInstance.SetFullscreen(1);

	render() {
		const { systems, currentLanguage, currentSystem } = this.state;
		return (
			<div className="App">
				<h1 className="app-title">
					<span className="letter-decoration">K</span>inship <span className="letter-decoration">T</span>erm <span className="letter-decoration">E</span>xplorer
				</h1>
				<GameMenu
					handleUpdateTreeLabels={this.handleUpdateTreeLabels}
					handleUpdateSystem={this.handleUpdateSystem}
					systemsData={systems}
					system={currentSystem}
					language={currentLanguage}
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
