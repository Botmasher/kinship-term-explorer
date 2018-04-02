import React, { Component } from 'react';
import { PropTypes } from 'prop-types';

// TODO async response from gameInstance before enabling menu choices besides "Primary"

export const GameMenu = ({ systemsData, system, language, handleUpdateTreeLabels, handleUpdateSystem }) => (
	<div>
		<div className="systems-list">
			<h2>kinship systems</h2>
			<ul>
				{Object.keys(systemsData).map(sysName => (
					sysName === system
						? <li key={sysName}><strong>{sysName}</strong></li> 
						: <li key={sysName}><a onClick={() => handleUpdateSystem(sysName)}>{sysName}</a></li>
				))}
			</ul>
		</div>
		<div className="systems-list">
			<h2>{system} Kinship</h2>
			<ul>
				{systemsData[system].map(langName => (
					<li key={langName}>
						{langName === language
							? <span><strong>{language}</strong></span>
							: <a onClick={() => handleUpdateTreeLabels(system, langName)}>{langName} terms</a>
						}
					</li>
				))}
			</ul>
		</div>
	</div>
);

GameMenu.propTypes = {
	systemsData: PropTypes.object.isRequired,
	system: PropTypes.string.isRequired,
	language: PropTypes.string.isRequired,
	handleUpdateTreeLabels: PropTypes.func.isRequired,
	handleUpdateSystem: PropTypes.func.isRequired,
};
