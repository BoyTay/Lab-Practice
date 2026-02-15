.model small
.stack 100h
.data
     a DB "Nhap ky tu thu nhat: $"
     b DB 13,10,"Nhap ky tu thu hai: $" 
     sum DB 13,10,"Ky tu tong : $"
     kqa DB ?
     kqb DB ?
.code
     mov ax, @data
     mov DS, ax
     
     lea dx, a
     mov ah, 9
     int 21h
     
     mov ah, 1
     int 21h
     mov kqa, al
     
     
     lea dx, b
     mov ah,9
     int 21h 
     
      mov ah, 1
     int 21h
     mov kqb, al
     
     lea dx, sum
     mov ah, 9
     int 21h
     
     mov dl, kqa
     add dl, kqb
     mov ah,2
     int 21h 
     
     mov ah, 4ch
     int 21h
     
     
     
end



