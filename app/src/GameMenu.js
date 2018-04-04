import React, { Component } from 'react';
import { PropTypes } from 'prop-types';

// TODO async response from gameInstance before enabling menu choices besides "Primary"

class GameMenu extends Component {
	constructor(props) {
		super(props);
		this.state = {
			showSubMenu: false
		};
	}

	chooseSystem(systemName) {
		this.setState({ showSubMenu: true });
		this.props.handleUpdateSystem(systemName);
	}

	render() {
		const { systemsData, system, language, handleUpdateTreeLabels, handleUpdateSystem } = this.props;
		return (
			<div id="game-menu">
				<div className={this.state.showSubMenu ? "systems-list systems-list-anim" : "systems-list"}>
					<ul>
						{Object.keys(systemsData).map(sysName => (
							sysName === system
								? <li className="selected" key={sysName}>{sysName}</li> 
								: <li key={sysName}><a onClick={() => this.chooseSystem(sysName)}>{sysName}</a></li>
						))}
					</ul>
					{this.state.showSubMenu && (
						<ul>
							{systemsData[system].map(langName => (
								<li key={langName}>
									{langName === language
										? <span><strong>{language} terms</strong></span>
										: <a onClick={() => handleUpdateTreeLabels(system, langName)}>{langName} terms</a>
									}
								</li>
							))}
						</ul>
					)}
				</div>
			</div>
		);
	}
}

GameMenu.propTypes = {
	systemsData: PropTypes.object.isRequired,
	system: PropTypes.string.isRequired,
	language: PropTypes.string.isRequired,
	handleUpdateTreeLabels: PropTypes.func.isRequired,
	handleUpdateSystem: PropTypes.func.isRequired,
};

export default GameMenu;
