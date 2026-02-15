.model small
.stack 100h
.data
 a db 'Hay nhap 1 ky tu: $'
 b db 13,10,'Ky tu dung truoc: $'
 c db ',da nhap: $'
 d db ',dung sau: $'
 e db ?   
.code 
 mov ax,@data
 mov ds,ax
  
 mov ah,9
 lea dx,a
 int 21h
 
 mov ah,1
 int 21h
 mov e,al
 
 mov ah,9
 lea dx,b
 int 21h 
 mov dl,e
 dec dl
 mov ah,2
 int 21h
 
 mov ah,9
 lea dx,c
 int 21h  
 mov dl,e
 mov ah,2
 int 21h
 
 mov ah,9
 lea dx,d
 int 21h  
 mov dl,e
 inc dl
 mov ah,2
 int 21h
 
 mov ah,4ch
 int 21h
 
end
 
 