# chartMerger

Guitar Hero 3 PC .chart file merger.

## Description

This is a tool made to merge several .chart files, in order to automate the making of the charts of solo medleys and compilations of the sort.

This does **not** merge audio files aswell - it still should be made manually, with a tool like Audacity.

## Usage

1. Open the desired .chart file in [FeedBack](https://github.com/TurkeyMan/feedback-editor/raw/master/Builds/FeedBack0.97b.zip);
2. With the up/down arrows, navigate to where you want the software to start reading the .chart;
3. Hit the E key and add an event called "CHARTMERGER_START" (capitalized);
4. Do the same to add an event where you want the software to end reading the .chart and go to the next one, called "CHARTMERGER_END";
5. Repeat steps above for every song you want to merge;
6. Then, make sure all the files are in the same folder;
7. If you want the songs to be read in a specific order, rename the files so they are in alphabetical order corresponding to the order you want (suggestion: add 01_..., 02_..., etc. to the beginning of the file name);
8. Then, just drag all .charts you edited and renamed into chartMerger.exe
9. There's no step 9, the .chart file is done (it is saved as chartMerger_output.chart)! You can open it in FeedBack if you want to check if everything is as it should be, or you can just merge the audios and import them into Guitar Hero 3 PC using GHTCP!

## Troubleshooting

* FeedBack freezes when opening/navigating through certain songs!
  * They probably have illegal commands, such as N 5 0 or N 6 0 - to fix that, simply open the .chart file in note pad, open the Find and Replace command (Ctrl+H) and Replace N 5 0 with E F and N 6 0 with E T.
  * Make sure to replace E F with N 5 0 and E T with N 6 0 after editing/merging the .chart, else you will not keep forced notes and tap notes.
* I don't want my chart to start at tick 0! What do I do?
  * Create a blank .chart file with only the CHARTMERGER_START and CHARTMERGER_END events and no notes whatsoever, rename it to something like 00.chart (to be sure it is the first .chart file in alphabetical order) and merge it together with the rest of the songs.
* The first note of one of the merged songs is incorrectly forced!
  * Make the .chart file editable as explained above and open it in FeedBack.
  * Navigate to where the unproperly forced note is, and delete its corresponding track event.
  * It *might* happen because the N 5 0 event is copied over when merging the chart - in the original song, it will force a HO/PO if the note before is more than 64 ticks afar, but on the merged song, if the same note is close to the last note of the previous song (less than 64 ticks afar), it will force a strum instead.
  * I will fix that in a future version of the program, when I have more available time (it shouldn't be *too* hard, just tricky). Stick with this, for now.
* I'm having an issue not listed here, or a solution listed here doesn't work!
  * Feel free to contact me at raphaelgoulart#1573 on Discord, and I'll do my best to help you.

## License

This software is released under the [MIT license](LICENSE). You're free to use it and modify it as you will, as long as you read and agree with its license.