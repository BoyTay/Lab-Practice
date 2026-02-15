.model small
.stack 100h
.data
    tmp db '0', '$'

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
            je Bai_10
            
            ;4. Doi thanh so tuong ung ( ky tu la '0' / '1') 
            sub al, '0'     ; chuyen ky so thanh gia tri so
            
            ;5. Dich trai BX
            shl bx, 1
            
            ;6. Dua tri da doi vao bit LSB cua BX
            or bl, al
            
            ;7. Quay lai buoc 2
            jmp Nhap
        
                
            Bai_10:
                ; 1. Lap 16 lan
                mov cx, 16
            
            Xuat_0:
                ; 2. Quay trai BX
                rol bx, 1
            
                ; 3. Kiem tra CF
                jc Xuat_1         ; Neu CF = 1, nhay den Xuat_1
                mov tmp, '0'      ; Neu CF = 0, xuat '0'
                jmp display
            
            Xuat_1:
                mov tmp, '1'      ; Xuat '1'
            
            display:
                ; Xuat ky tu
                mov ah, 09h          ; Xuat chuoi
                lea dx, tmp
                int 21h
            
                ; Giam CX va kiem tra
                loop Xuat_0
            
                ; Ket thuc chuong trinh
                mov ah, 4Ch          
                int 21h
main endp
end 