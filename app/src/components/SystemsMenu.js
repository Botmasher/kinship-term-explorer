import React from 'react';
import PropTypes from 'prop-types';

const SystemsMenu = ({systems, currentSystemId, handleUpdateSystem}) => (
	<ul>
		{systems.map(systemMap => (
			systemMap.id === currentSystemId
				? <li className="selected" key={systemMap.id}>{systemMap.name}</li> 
				: <li key={systemMap.id}><a onClick={() => handleUpdateSystem(systemMap.id)}>{systemMap.name}</a></li>
		))}
	</ul>
);

SystemsMenu.propTypes = {
	systems: PropTypes.array.isRequired,
	currentSystemId: PropTypes.string.isRequired,
	handleUpdateSystem: PropTypes.func.isRequired
};

export default SystemsMenu;
