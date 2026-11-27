Forest Ground Lite (free): how to use it in Tiled
==================================================

What is in the pack
  Ground, 96 x 96 px tiles
    ground_fills.tsx      Grass, four tiles that fit together in any order. Lay them everywhere as the base.
    ground_edges.tsx      Dirt with its edges: 14 edge shapes and four fill variants, one terrain set ("Dirt edge").
  Standing pieces (object layers)
    Trees: oak_1, pine.   Bush: bush_round.   Rock: rock_medium.
  Decals (small pictures with no shadow)
    tuft_1, tuft_2 (grass), flowers_yellow, pebbles_1 (for the dirt path).
  Example maps (24 x 16 tiles), the same forest path scene twice:
    example_map.tmx            pieces and their shadows on separate layers (the shadows can be hidden or faded)
    example_map_shadowed.tmx   each piece and its shadow already in one picture
  preview_shadowed.png and preview_adjustable.png are pictures of the two maps.

Ground (tile layers)
  Grass (base) is laid under everything. Dirt is a layer on top of it. Pick "Dirt edge" in ground_edges.tsx and paint
  with the Terrain Brush: the edges draw themselves. Grass has no edge tiles, because it is the layer underneath.

Two ways to place trees, bushes and rocks (object layers, Insert Tile, key T)

  1. Ready to place: nature_shadowed.tsx
     Each picture already has its shadow in it. Drag one onto the map and you are done.
     Placement: put the picture's bottom centre 48 px (half a tile) below where the foot should stand.
     Example: for a tree to stand on tile column C, row R, place it at x = C * 96 + 48, y = (R + 1) * 96 + 48.
     The shadow cannot be turned off or recoloured. The light comes from the upper left.

  2. Adjustable: nature.tsx
     The plain pieces and the separate *_shadow pictures. Place the piece with its foot on the point where it stands:
     x = C * 96 + 48, y = (R + 1) * 96. Every picture is anchored at the middle of its bottom edge, so snapping puts the
     foot there. Then place the piece's shadow in the Shadows layer; the easiest way is to copy a piece and its shadow
     from example_map.tmx together. The Shadows layer can be hidden, faded or replaced for your own lighting.
     nature.tsx also holds the decals.

  Snapping: turn on View > Snap to Fine Grid and, in Preferences > Interface, set Fine grid divisions to 2. Objects
  then snap to tile middles and tile corners.

Tips
  Do not place trees in rows. Trees look natural in groups and gaps, with their crowns overlapping. Put bushes and tufts at
  the foot of trees. Trees, bushes and rocks stand on grass, not on dirt.

Sizes: resize the pieces
  These are painted pictures, not pixel art, so they can be resized. The example maps do it: the trees, bushes and rocks in them
  are scaled between about 0.55 and 1.3 times (rocks and bushes up to about 1.5), which is what makes the forest look natural: small
  young trees between big old ones. In Tiled, select an object and change its Width and Height, keeping the proportions. Keep the
  bottom centre where it is (the pieces are anchored there) and scale a shadow together with its piece. Sizes between about 0.5 and
  1.3 times stay sharp; much above 1.3 times the picture goes soft. Do not flip a picture: the light comes from the upper left.

Recommended setup
  Tile size 96 x 96 px, shown at 1:1 (one tile = 96 screen pixels): a 1920 x 1080 screen shows 20 x 11 tiles and looks best. A
  smaller screen can scale everything down (for example 0.67 for a 1280 x 720 screen); scaling down stays sharp. Use smooth
  (linear) texture filtering, not "nearest": the shading is soft. Avoid scaling the whole game up by 2 times or more.

Made with AI
  The pictures in this pack were made with an AI image model (ChatGPT) from the author's own blank templates and prompts,
  then cut, scaled, colour graded and assembled with tools by the author. No picture from any other tileset or artist was
  used as a reference or a base.

Licence
  Same terms as the full pack. Use in free and commercial games, edit and resize freely. Credit is appreciated, not required.
  Do not resell or redistribute the asset files themselves, and do not use them to train AI models. The full text is in LICENSE.txt.
  This is a free sample of the full pack, Forest Ground and Nature (more grounds, trees, a camp, an elder tree and more).
  Author: judgemon21, https://judgemon21.itch.io
