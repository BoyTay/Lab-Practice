.model small
.stack 100h
.data
    tmp db ?

.code
    main proc
        ;1. Xoa BX
        xor bx, bx
        
        Nhap:
            ;2. Nhap mot ky tu
            mov ah, 1
            int 21h
            mov tmp, al
            
            ;3. Neu ky tu la ENTER thi nhay den 8(Ket thuc)
            cmp tmp, 13     ; kiem tra ky tu ENTER 
            je Thoat
            
            ;4. Doi thanh so tuong ung ( ky tu la '0' / '1') 
            sub al, '0'     ; chuyen ky so thanh gia tri so
            
            ;5. Dich trai BX
            shl bx, 1
            
            ;6. Dua tri da doi vao bit LSB cua BX
            or bl, al
            
            ;7. Quay lai buoc 2
            jmp Nhap
        Thoat:
        ;8. Ket thuc
            mov ah, 4ch
            int 21h   
     
    main endp      

end 