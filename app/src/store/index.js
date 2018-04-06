export const store = {
	systems: {
		'global': {
			name: '(Global Types)',
			languages: ['Primary'],
			description: 'A set of kin types underlying the labels found in specific systems. Differently labeled members are assigned different colors. Compare Sudanese kinship.'
		},
		'inuit': {
			name: 'Inuit',
			languages: ['English', 'Iñupiaq'],
			description: 'Splits lineal and collateral kin. This system lumps cousins and aunts-uncles, using the same terms no matter the crossness or which side of the family.'
		},
		'hawaiian': {
			name: 'Hawaiʻian',
			languages: ['Hawaiian'],
			description: 'Primarily distinguishes generations. Press ego ("you") to watch sibling terms change if you are a brother or sister. Sibling age matters, too (not shown).'
		},
		'sudanese': {
			name: 'Sudanese',
			languages: ['Latin'],
			description: 'Remember those basic kin types? This system moves closer to them by using distinct terms for different kin types in relation to ego. Contrast Hawaiʻian.'
		},
		'iroquois': {
			name: 'Iroquois',
			languages: ['Yanomamö', 'Navajo'],
			description: 'Ever needed to tell your parallel and cross-cousins apart? This system splits aunts and uncles based on sibling sameness and then cousins based on crossness.'
		},
		'crow': {
			name: 'Crow',
			languages: ['Akan'],
			description: 'This system also marks crossness, but passes father and aunt terms through father\'s sister and children. Explained as matrilineal. Like Omaha but flipped!'
		},
		'omaha': {
			name: 'Omaha',
			languages: ['Igbo', 'Dani'],
			description: 'Crossness as in Iroquois, but passes mother and uncle terms through mother\'s brother and children. Explained as patrilineal. Like Crow but flipped!'
		}
	}
};
