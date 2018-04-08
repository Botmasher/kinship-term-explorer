import React, { Component } from 'react';
import { PropTypes } from 'prop-types';

// TODO async response from gameInstance before enabling menu choices besides "Primary"
// TODO break out list and submenu components

class GameMenu extends Component {
	constructor(props) {
		super(props);
		this.state = {
			showSubMenu: true
		};
	}

	chooseSystem(systemName) {
		this.setState({ showSubMenu: true });
		this.props.handleUpdateSystem(systemName);
	}

	render() {
		const { systems, currentSystemId, currentLanguage, currentDescription } = this.props;
		return (
			<div id="game-menu">
				<div className={this.state.showSubMenu ? "systems-list systems-list-anim" : "systems-list"}>
					<ul>
						{systems.map(systemMap => (
							systemMap.id === currentSystemId
								? <li className="selected" key={systemMap.id}>{systemMap.name}</li> 
								: <li key={systemMap.id}><a onClick={() => this.chooseSystem(systemMap.id)}>{systemMap.name}</a></li>
						))}
					</ul>
					{this.state.showSubMenu && (
						<p key={currentSystemId} className="system-description-anim">
							{currentLanguage !== "Primary" && (
								<span>
									<em>example:</em>&nbsp;
									<a href={`https://en.wikipedia.org/wiki/${currentLanguage}_language`}>
										<strong>{currentLanguage}</strong>
									</a>.&nbsp;&nbsp;
								</span>
							)}
							<span>{currentDescription}</span>
						</p>
					)}
				</div>
			</div>
		);
	}
}

GameMenu.propTypes = {
	systems: PropTypes.array.isRequired,
	currentSystemId: PropTypes.string.isRequired,
	currentLanguage: PropTypes.string.isRequired,
	currentDescription: PropTypes.string,
	handleUpdateSystem: PropTypes.func.isRequired
};

export default GameMenu;
