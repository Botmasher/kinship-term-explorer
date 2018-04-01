import React, { Component } from 'react';
import './App.css';
import { GameMenu } from './GameMenu';
import { GameContainer } from './GameContainer';

class App extends Component {
	constructor(props) {
		super(props);
		this.state = {
			currentSystem: ['Primary'],
			currentLanguage: ['Primary'],
			systems: {
				'Primary': ['Primary'],
				'Inuit': ['English', 'Iñupiaq']
			}
		};
	}

	handleUpdateTreeLabels = (systemName, languageName) => {
		window.gameInstance && window.gameInstance.SendMessage('Nodes Manager', 'LabelFamilyMembers', languageName);
		this.setState({currentSystem: systemName, currentLanguage: languageName});
	};

	setFullscreen = () => this.gameInstance.SetFullscreen(1);

	render() {
		const { systems, currentLanguage, currentSystem } = this.state;
		return (
			<div className = "App">
				<h1>Kinship Term Explorer</h1>
				<GameMenu handleUpdateTreeLabels={this.handleUpdateTreeLabels} systems={systems} system={currentSystem} language={currentLanguage} />
				<GameContainer title={"Kinship Term Explorer"} setFullscreen={this.setFullscreen} />
			</div>
		);
	}
}

export default App;
