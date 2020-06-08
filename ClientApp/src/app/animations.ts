import {
  animate,
  animateChild,
  group,
  query,
  style,
  transition,
  trigger,
} from '@angular/animations';

export const slider = trigger('routeAnimations', [
  // 'f' stands for first and 'l' for last
  transition('f => *', slideTo('left')),
  transition('l => *', slideTo('right')),
  transition('* => f', slideTo('right')),
  transition('* => l', slideTo('left')),
  transition('2 => 3', slideTo('left')),
  transition('3 => 2', slideTo('right')),
  transition('void => *', []),
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
    query(':enter', [style({ [direction]: '-100%' })]),
    query(':leave', animateChild(), optional),
    group([
      query(
        ':leave',
        [animate('700ms ease-out', style({ [direction]: '100%' }))],
        optional
      ),
      query(':enter', [
        animate('700ms ease-out', style({ [direction]: '0%' })),
      ]),
    ]),
    query(':enter', animateChild()),

    // Normalize the page style... Might not be necessary

    // Required only if you have child animations on the page
  ];
}
