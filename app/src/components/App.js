import React, { Component } from 'react';
import GameMenu from './GameMenu';
import GameContainer from './GameContainer';
import { store } from '../store';

class App extends Component {
	constructor(props) {
		super(props);
		this.state = {
			gameLoaded: false,
			currentSystem: 'global',
			currentLanguage: 'Primary'
		};
	}

	// TODO rework this function for updating selected language (not used in demo but handy in future)
	handleUpdateTreeLabels = (systemName, languageName) => {
		window.gameInstance && window.gameLoaded && window.gameInstance.SendMessage('Nodes Manager', 'LabelFamilyMembers', languageName);
		this.setState({currentSystem: systemName, currentLanguage: languageName});
	};

	// TODO check if gameInstance loading complete before setting ui or passing data
	handleUpdateSystem = systemName => {
		if (!window.gameLoaded) return;
		const { systems } = store;
		this.setState({gameLoaded: true, currentSystem: systemName, currentLanguage: systems[systemName].languages[0]}, () => (
			window.gameInstance && (
				window.gameInstance.SendMessage('Nodes Manager', 'LabelFamilyMembers', systems[systemName].languages[0])
			)
		));
	};

	setFullscreen = () => window.gameInstance.SetFullscreen(1);

	componentDidMount() {
		window.setTimeout(() => this.setState({gameLoaded: true}), 5000);
	}

	render() {
		console.log(window.gameLoaded);
		const { currentSystem, currentLanguage } = this.state;
		const { systems } = store;
		return (
			<div className="App">
				<h1 className="app-title">
					<span className="letter-decoration">K</span>inship <span className="letter-decoration">T</span>erm <span className="letter-decoration">E</span>xplorer
				</h1>
				{this.state.gameLoaded
					?	<GameMenu
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
					: <p>Loading game...</p>
				}
				<GameContainer
					title={"Kinship Term Explorer"}
					setFullscreen={this.setFullscreen}
				/>
			</div>
		);
	}
}

export default App;
