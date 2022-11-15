package com.fhict.sociable.DTO;

import com.fhict.sociable.Model.Status;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class TextMessageDTO {

    private String senderName;
    private String recieverName;
    private String message;
    private String date;
    private Status status;


}
