import React, { Component } from 'react';
import './App.css';
import GameMenu from './GameMenu';
import { GameContainer } from './GameContainer';

// TODO rework data to default load primaries per system (current "Primary" would be for Sudanese)

class App extends Component {
	constructor(props) {
		super(props);
		this.state = {
			currentSystem: '',
			currentLanguage: 'Primary',
			systems: {
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
				<h1 className="app-title">Kinship Term Explorer</h1>
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
