import React from 'react';
import { PropTypes } from 'prop-types';

// TODO async response from gameInstance before enabling menu choices besides "Primary"
// TODO break out list and submenu components

const GameMenu = ({ systems, currentSystemId, currentLanguage, currentDescription, handleUpdateSystem, isGameLoaded, unloadedClicks }) => (
	<div id="game-menu">
		<div className="systems-list systems-list-anim">
			<ul>
				{systems.map(systemMap => (
					systemMap.id === currentSystemId
						? <li className="selected" key={systemMap.id}>{systemMap.name}</li> 
						: <li key={systemMap.id}><a onClick={() => handleUpdateSystem(systemMap.id)}>{systemMap.name}</a></li>
				))}
			</ul>
			{isGameLoaded
				?	<p key={currentSystemId} className="system-description-anim">
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
				: <p key={`unloaded-message-${unloadedClicks}`} className="menu-loading">Currently loading game instance.<br/><br/></p>
			}
		</div>
	</div>
);

GameMenu.propTypes = {
	systems: PropTypes.array.isRequired,
	currentSystemId: PropTypes.string.isRequired,
	currentLanguage: PropTypes.string.isRequired,
	currentDescription: PropTypes.string,
	handleUpdateSystem: PropTypes.func.isRequired,
	isGameLoaded: PropTypes.bool.isRequired,
	unloadedClicks: PropTypes.number.isRequired
};

export default GameMenu;
