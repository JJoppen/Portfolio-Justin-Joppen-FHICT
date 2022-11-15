package com.fhict.sociable.Controller;

import com.fhict.sociable.DTO.TextMessageDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.messaging.handler.annotation.MessageMapping;
import org.springframework.messaging.handler.annotation.Payload;
import org.springframework.messaging.handler.annotation.SendTo;
import org.springframework.messaging.simp.SimpMessagingTemplate;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.RestController;

@RestController
@CrossOrigin(origins = "http://localhost:3000/")
public class WebSocketTextController {

    @Autowired
    private SimpMessagingTemplate simpMessagingTemplate;

    @MessageMapping("/message") // /app/message
    @SendTo("/chatroom/public")
    private TextMessageDTO recievePublicMessage(@Payload TextMessageDTO messageDTO){
        return messageDTO;
    }

    @MessageMapping("/private-message")
    public TextMessageDTO recievePrivateMessage(@Payload TextMessageDTO messageDTO){

        simpMessagingTemplate.convertAndSendToUser(messageDTO.getRecieverName(),"/private",messageDTO);// /user/username/private
        return messageDTO;
    }
}
