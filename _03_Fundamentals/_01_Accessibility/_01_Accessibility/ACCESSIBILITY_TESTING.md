# Accessibility testing checklist (Android & iOS)

## General WCAG-aligned checks
- All images have `SemanticProperties.Description` describing purpose
- Interactive elements (buttons, entries, toggles, sliders) expose meaningful descriptions and hints
- Headings use `SemanticProperties.HeadingLevel` to support semantic navigation
- Focus order follows visual order; no hidden elements in the accessibility tree
- Controls remain operable with external keyboards and screen readers
- Sufficient touch target sizes (?44x44 pt)
- Dynamic content changes announce status where appropriate (LiveRegion if added)

## Android (TalkBack)
- Enable: Settings ? Accessibility ? TalkBack ? toggle On
- Verify swipe navigation reaches every control and reads description + hint
- Confirm slider and switches expose value/state changes via TalkBack
- Check images announce descriptions instead of filenames
- Test landscape and portrait for consistent focus order

## iOS (VoiceOver)
- Enable: Settings ? Accessibility ? VoiceOver ? toggle On (or triple-click Side/Home button if configured)
- Swipe through controls; ensure headings are discoverable via rotor navigation
- Confirm actions (double-tap, two-finger double-tap) activate controls as expected
- Validate hints guide users and descriptions match control purpose
- Check that text size adjustments don’t break layout or focus order

## Notes for testers
- Use hardware keyboard shortcuts where available to confirm keyboard support
- Test with light/dark themes for contrast regressions
- Document any control without a description, unclear hint, or incorrect heading level
