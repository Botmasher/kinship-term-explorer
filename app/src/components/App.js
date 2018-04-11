import React, { Component } from 'react';
import GameMenu from './GameMenu';
import GameContainer from './GameContainer';
import { store } from '../store';

class App extends Component {
	constructor(props) {
		super(props);
		this.state = {
			isLoaded: false,
			unloadedClicks: 0,
			currentSystem: 'global',
			currentLanguage: 'Primary'
		};
	}

	// TODO rework this function for updating selected language (not used in demo but handy in future)
	handleUpdateTreeLabels = (systemName, languageName) => {
		window.gameInstance && window.gameLoaded && window.gameInstance.SendMessage('Nodes Manager', 'LabelFamilyMembers', languageName);
		this.setState({currentSystem: systemName, currentLanguage: languageName});
	};

	handleUpdateSystem = systemName => {
		if (!window.gameLoaded) {
			this.setState((prevState) => ({unloadedClicks: prevState.unloadedClicks+1}));
			return;
		}
		const { systems } = store;
		// pick the first language in the system and message game to update using its data for that language
		this.setState({isLoaded: true, currentSystem: systemName, currentLanguage: systems[systemName].languages[0]}, () => (
			window.gameInstance && (
				window.gameInstance.SendMessage('Nodes Manager', 'LabelFamilyMembers', systems[systemName].languages[0])
			)
		));
	};

	setFullscreen = () => window.gameInstance.SetFullscreen(1);

	componentDidMount() {
		// check that game has fully loaded (used for e.g. mounting menu description)
		if (!this.state.isLoaded) {
			const interval = window.setInterval(() => {
				window.gameLoaded && window.clearInterval(interval);
				window.gameLoaded && this.setState({isLoaded: true});
			}, 1000);
		}
	}

	render() {
		const { currentSystem, currentLanguage, isLoaded, unloadedClicks } = this.state;
		const { systems } = store;
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
					isGameLoaded={isLoaded}
					unloadedClicks={unloadedClicks}
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
