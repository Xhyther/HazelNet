# Kards.Net UI Design Specifications

## Typography

### Font Family
- **Primary**: `-apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, sans-serif`
- **Fallback**: System default sans-serif fonts

### Font Sizes & Weights
| Element | Size | Weight | Color |
|---------|------|--------|-------|
| App Title (Kards.Net) | 20px | Bold (700) | #1e293b |
| Page Header (My Decks) | 28px | Bold (700) | #1e293b |
| Page Subtitle | 14px | Regular (400) | #64748b |
| Deck Card Title | 18px | Bold (700) | #1e293b |
| Navigation Links | 14px | Medium (500) | #64748b / #334155 (hover) |
| Button Text | 13-14px | Medium (600) | Context dependent |
| Card Count Badge | 12px | SemiBold (600) | #1e40af |
| Last Studied Info | 13px | Regular (400) | #64748b |
| Search Placeholder | 14px | Regular (400) | #94a3b8 |

## Color Palette

### Primary Colors
| Name | Hex Code | Usage |
|------|----------|-------|
| Primary Blue | #3b82f6 | Study buttons, active states |
| Primary Blue Hover | #2563eb | Button hover states |
| Success Green | #10b981 | Create button background |
| Success Green Dark | #059669 | Create button hover |

### Background Colors
| Name | Hex Code | Usage |
|------|----------|-------|
| App Background | #f8fafc | Main app background |
| Card Background | #ffffff | All cards and sidebar |
| Input Background | #f8fafc | Search box background |
| Badge Background | #dbeafe | Card count badges |
| Edit Button Background | #f1f5f9 | Edit button background |
| Edit Button Hover | #e2e8f0 | Edit button hover state |
| Nav Active Background | #e2e8f0 | Active navigation item |
| Nav Hover Background | #f1f5f9 | Navigation hover state |

### Text Colors
| Name | Hex Code | Usage |
|------|----------|-------|
| Primary Text | #1e293b | Headers, titles, active nav |
| Secondary Text | #64748b | Subtitles, info text, nav items |
| Tertiary Text | #475569 | Edit button text |
| Muted Text | #94a3b8 | Placeholder text |
| Badge Text | #1e40af | Card count text |
| Button Text (White) | #ffffff | Study button, create button |

### Border Colors
| Name | Hex Code | Usage |
|------|----------|-------|
| Light Border | #e2e8f0 | Sidebar border, header border, input border |

## Gradients

### Logo Gradient
```css
background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
```

### Create Button Gradient
```css
background: linear-gradient(135deg, #10b981 0%, #059669 100%);
```

### Card Top Border Gradients
| Card Type | Gradient |
|-----------|----------|
| Default | `linear-gradient(135deg, #667eea 0%, #764ba2 100%)` |
| Pokemon | `linear-gradient(135deg, #ff6b6b 0%, #ee5a24 100%)` |
| CS/Programming | `linear-gradient(135deg, #4ecdc4 0%, #44a08d 100%)` |
| Github | `linear-gradient(135deg, #24292e 0%, #586069 100%)` |

## Spacing & Layout

### Padding & Margins
| Element | Padding | Margin |
|---------|---------|--------|
| Sidebar | 24px 20px | - |
| Logo Section | - | 0 0 32px 0 |
| Navigation Links | 12px 16px | - |
| Navigation Items | - | 0 0 4px 0 |
| Header | 20px 24px | - |
| Content Area | 24px | - |
| Deck Cards | 24px | - |
| Card Grid Gap | - | 20px |
| Button Padding (Small) | 10px 16px | - |
| Button Padding (Large) | 12px 20px | - |
| Search Box | 10px 16px | - |
| Card Count Badge | 6px 12px | - |

### Dimensions
| Element | Width | Height | Other |
|---------|-------|--------|-------|
| Sidebar | 280px | 100vh | Fixed |
| Logo Circle | 32px | 32px | Circle |
| Search Box | 240px | - | - |
| Card Grid | auto-fill | - | minmax(320px, 1fr) |

## Border Radius

| Element | Border Radius |
|---------|---------------|
| Deck Cards | 12px |
| Buttons | 6px |
| Create Button | 8px |
| Navigation Links | 8px |
| Search Box | 8px |
| Card Count Badge | 12px |
| Logo Circle | 50% (circle) |
| Stats Overlay | 20px |

## Shadows

### Card Shadows
| State | Box Shadow |
|-------|------------|
| Default | `0 1px 3px rgba(0, 0, 0, 0.1), 0 1px 2px rgba(0, 0, 0, 0.06)` |
| Hover | `0 10px 25px rgba(0, 0, 0, 0.15)` |

### Button Shadows (Optional)
- Subtle shadow on hover: `0 2px 4px rgba(0, 0, 0, 0.1)`

## Animations & Transitions

### Transition Durations
| Element | Duration | Easing |
|---------|----------|---------|
| Navigation Links | 0.2s | ease |
| Deck Cards | 0.3s | ease |
| Buttons | 0.2s | ease |
| Create Button Transform | 0.2s | ease |

### Transform Effects
| Element | Hover Transform |
|---------|----------------|
| Deck Cards | `translateY(-4px)` |
| Create Button | `translateY(-1px)` |
| Study Button (Click) | `scale(0.95)` then `scale(1)` |

## Grid & Layout

### CSS Grid Properties
```css
.deck-grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(320px, 1fr));
  gap: 20px;
}
```

### Flexbox Properties
```css
.app-container {
  display: flex;
  height: 100vh;
}

.header {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.deck-actions {
  display: flex;
  gap: 8px;
}
```

## Responsive Breakpoints

### Mobile (768 px and below)
- Sidebar becomes full width horizontal navigation
- Navigation items scroll horizontally
- Card grid becomes single column
- Reduced padding on mobile elements

## Special Effects

### Card Top Border Accent
- 4px height colored strip at top of each card
- Uses gradient backgrounds for visual categorization

### Backdrop Filter (Modern browsers)
```css
backdrop-filter: blur(10 px);
```
- Used on stats overlay for glassmorphism effect

### Icon Specifications
| Icon | Unicode/Emoji | Size |
|------|---------------|------|
| Dashboard | 📊 | 16px |
| Card Decks | 🗂️ | 16px |
| Study | 📚 | 16px |
| Statistics | 📈 | 16px |
| Plus (Create) | + | 16px |

## Interactive States

### Button States
| State | Background | Transform | Duration |
|-------|------------|-----------|----------|
| Normal | As specified | none | - |
| Hover | Darker shade | translateY(-1px) | 0.2s |
| Active/Click | Darker + scale | scale(0.95) | 0.15s |

### Navigation States
| State | Background | Text Color |
|-------|------------|------------|
| Normal | transparent | #64748b |
| Hover | #f1f5f9 | #334155 |
| Active | #e2e8f0 | #1e293b |

This comprehensive specification should give you everything needed to recreate the modern UI design in your Avalonia AXAML application.