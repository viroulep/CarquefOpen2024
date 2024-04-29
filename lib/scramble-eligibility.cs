
# Spreadsheet is public here:
# https://docs.google.com/spreadsheets/d/1iA5fnm6euEk5bhhDHcEFa2amVbAyA95zIJDYJrBsEmU/edit?usp=sharing

ReadSpreadsheet("1iA5fnm6euEk5bhhDHcEFa2amVbAyA95zIJDYJrBsEmU")

SetProperty(Persons((NumberProperty("scrambles") == 1)), "can-scramble", true)

# Permitted Scramblers
Define("CanScrambleEvent",
        And(In({1, Event}, RegisteredEvents()), BooleanProperty("can-scramble")))
