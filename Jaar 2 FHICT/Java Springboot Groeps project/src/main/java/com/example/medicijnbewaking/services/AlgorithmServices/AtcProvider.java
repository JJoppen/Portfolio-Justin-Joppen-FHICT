package com.example.medicijnbewaking.services.AlgorithmServices;

import lombok.Getter;
import lombok.NoArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Getter
@NoArgsConstructor
@Service
public class AtcProvider {

    private List<String> bifosfonaten =new ArrayList<>(List.of(
            "M05BA04","M05BA02","M05BA06","M05BA03","M05BA07","M05BA08","M05BB01","M05BB02","M05BB03","M05BB05","M05BB04"));
    private List<String> otherCalciumRegulators = new ArrayList<>(List.of(
            "G03XC02","M05BX04","G03XC01","M05BX03","H05AA02"));

    private List<String> corticosteroïd = new ArrayList<>(List.of(
            "R03BA02","R03BA05","R03AK10","R03AK07","R03BA01","R03BA08","R03AK06","R03AK08","R03AK12","R03AK11"));

}
