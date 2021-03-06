import {
  animate,
  animateChild,
  group,
  query,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';

export const treeAnimation = trigger('treeAnimation', [
  state(
    'hide',
    style({
      height: 0,
    })
  ),
  state(
    'show',
    style({
      height: '*',
    })
  ),
  state('*', style({ display: 'none' })),
  transition('* => *', [animate('600ms cubic-bezier(0.25, 0.8, 0.25, 1)')]),
]);

export const rowAnimation = trigger('rowAnimation', [
  transition('* => void', [animate('0ms', style({ display: 'none' }))]),
]);
export const slider = trigger('routeAnimations', [
  // 'f' stands for first and 'l' for last
  // transition('void => *', []),
  transition(
    (fromState, toState) => fromState && fromState === 'sf',
    slideTo('left')
  ),
  transition((fromState, toState) => fromState === 'sl', slideTo('right')),
  transition(
    (fromState, toState) =>
      fromState && fromState.startsWith('s') && toState == 'sf',
    slideTo('right')
  ),
  transition(
    (fromState, toState) =>
      fromState && fromState.startsWith('s') && toState == 'sl',
    slideTo('left')
  ),
  transition('s2 => s3', slideTo('left')),
  transition('s2 => s4', slideTo('left')),
  transition('s3 => s2', slideTo('right')),
  transition('s3 => s4', slideTo('left')),
  transition('s4 => s3', slideTo('right')),
  transition('s4 => s2', slideTo('right')),
]);
export const verticalSlider = trigger('routeAnimations', [
  // 'f' stands for first and 'l' for last
  // transition('void => *', []),
  transition('f => *', transformTo({ x: 0, y: 100 })),
  transition('l => *', transformTo({ x: 0, y: -100 })),
  transition('* => f', transformTo({ x: 0, y: -100 })),
  transition('* => l', transformTo({ x: 0, y: 100 })),
  transition('2 => 3', transformTo({ x: 0, y: 100 })),
  transition('3 => 2', transformTo({ x: 0, y: -100 })),
]);
function slideTo(direction) {
  const optional = { optional: true };
  return [
    style({ position: 'relative' }),
    query(
      ':enter, :leave',
      [
        style({
          position: 'absolute',
          top: 0,
          [direction]: 0,
          width: '100%',
        }),
      ],
      optional
    ),
    query(':enter', [style({ [direction]: '-100%' })], optional),
    query(':leave', animateChild(), optional),
    group([
      query(
        ':leave',
        [animate('800ms ease-out', style({ [direction]: '100%' }))],
        optional
      ),
      query(
        ':enter',
        [animate('800ms ease-out', style({ [direction]: '0%' }))],
        optional
      ),
    ]),
    query(':enter', animateChild(), optional),

    // Normalize the page style... Might not be necessary

    // Required only if you have child animations on the page
  ];
}
function transformTo({ x = 100, y = 0 }) {
  const optional = { optional: true };
  return [
    style({ position: 'relative' }),
    query(
      ':enter, :leave',
      [
        style({
          position: 'absolute',
          top: 0,
          left: 0,
          width: '100%',
        }),
      ],
      optional
    ),
    query(':enter', [style({ transform: `translate(${x}%, ${-1 * y}%) ` })]),
    group([
      query(
        ':leave',
        [
          animate(
            '800ms ease-out',
            style({ transform: `translate(${x}%, ${y}%) ` })
          ),
        ],
        optional
      ),
      query(
        ':enter',
        [animate('800ms ease-out', style({ transform: `translate(0, 0)` }))],
        optional
      ),
    ]),
    query('router-outlet ~ *', [style({}), animate(1, style({}))], {
      optional: true,
    }),
    query(':enter', animateChild(), optional),
  ];
}
