import React from 'react';
import PropTypes from 'prop-types';

const SystemDescription = ({currentSystemId, currentLanguage, currentDescription}) => (
	<div key={currentSystemId} className="system-description-anim">
		{currentLanguage !== "Primary" && (
			<span>
				<em>example:</em>&nbsp;
				<a href={`https://en.wikipedia.org/wiki/${currentLanguage}_language`}>
					<strong>{currentLanguage}</strong>
				</a>.&nbsp;&nbsp;
			</span>
		)}
		<span>{currentDescription}</span>
	</div>
);

SystemDescription.propTypes = {
	currentSystemId: PropTypes.string.isRequired,
	currentLanguage: PropTypes.string.isRequired,
	currentDescription: PropTypes.string.isRequired
};

export default SystemDescription;
