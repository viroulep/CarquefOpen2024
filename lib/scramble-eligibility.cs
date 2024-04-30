
# Spreadsheet is public here:
# https://docs.google.com/spreadsheets/d/1iA5fnm6euEk5bhhDHcEFa2amVbAyA95zIJDYJrBsEmU/edit?usp=sharing

#ReadSpreadsheet("1iA5fnm6euEk5bhhDHcEFa2amVbAyA95zIJDYJrBsEmU")

# Google is unstable enough that I need to do this
# uncomment later
Define("Scramblers", [2018NEVE02, 2021MUSS01, 2019GASN01, 2021AUBA01, 2023CHAU12, 2008PIAU01, 2021HEBE01, 2023LEPR01, 2022PRUV01, 2017SAFO01, 2019MAIG01, 2022FERR16, 2022DARM01, 2018AUBR01, 2016BRAU02, 2023CHAR07, 2023BERN07, 2008ERBI01, 2008MORE02, 2018TILL02, 2021DAMM01, 2017ROUX01, 2014SEBA01, 2008HANK01, 2022MERL02, 2024BEHI01, 2019CORA01, 2022DUFO01, 2022CHAU04, 2022ROYM01, 2008CHOT01, 2019LEFE02, 2009BONN01, 2008VIRO01, 2016DURE02, 2017RIVA09, 2020ROUY01, 2022HATI01, 2010WEYE02, 2022HAME01, 2016PYWI01])
SetProperty(Scramblers(), "scrambles", 1)

SetProperty(Persons(true), "can-scramble", (NumberProperty("scrambles") == 1))

SetProperty([2009BONN01, 2017PRES04], "scoretaking", true)

# Permitted Scramblers
Define("CanScrambleEvent",
       And(
         In({1, Event}, RegisteredEvents()),
         BooleanProperty("can-scramble"),
         (PsychSheetPosition({1, Event}) < 20)
       ))
