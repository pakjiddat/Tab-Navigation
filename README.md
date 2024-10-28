# Tab-Navigation
Sample Unity application demonstrating how to navigate text boxes and drop downs using buttons

## To use Tab Navigation:

- Install EasyTab Unity package (right click Assets. import package -> custom package)
- Create Scripts folder and import the files: CustomDropdown, DownArrow, Enter, ForwardNavigation, ReverseNavigation and UpArrow
- Set input field that should have focus at the start. This can be done by clicking on EventSystem and then dragging the input field over the First Selected property
- Attach EasyTab script to all navigation buttons. Set selectable recognition property to "As not selectable"
- Attach the imported scripts to the navigation buttons
- Create text boxes and drop downs in scene tab
- Attach CustomDropdown.cs script to all the drop downs in the scene
- Set the selectable color of each text box and drop down from the properties inspector