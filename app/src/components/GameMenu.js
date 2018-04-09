import React from 'react';
import { PropTypes } from 'prop-types';
import SystemsMenu from './SystemsMenu';
import SystemDescription from './SystemDescription';

const GameMenu = ({ systems, currentSystemId, currentLanguage, currentDescription, handleUpdateSystem, isGameLoaded, unloadedClicks }) => (
	<div id="game-menu">
		<div className="systems-list systems-list-anim">
			<SystemsMenu systems={systems} currentSystemId={currentSystemId} handleUpdateSystem={handleUpdateSystem} />
			{isGameLoaded
				?	<SystemDescription currentSystemId={currentSystemId} currentLanguage={currentLanguage} currentDescription={currentDescription} />
				: <div key={`unloaded-message-${unloadedClicks}`} className="menu-loading">Currently loading game instance.<br/><br/></div>
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
