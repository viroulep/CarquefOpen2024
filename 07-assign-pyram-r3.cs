#include "lib/helpers.cs"


#AddResults(_pyram-r3,
  #Persons(And((PsychSheetPosition(_pyram) > 3), (PsychSheetPosition(_pyram) < 17))))

Define("SubsequentRound", _pyram-r3)

#include "lib/basic-assign-subsequent.cs"
