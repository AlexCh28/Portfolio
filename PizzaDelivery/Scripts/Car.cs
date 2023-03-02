using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Car : MonoBehaviour
{
    public static event Action<int> OnScoreChange;

    // куб, в сторону которого машина будет поворачиваться и ехать
    [SerializeField] Transform cube;
    [SerializeField] Transform leftWheel, rightWheel;
    [SerializeField] float speed=5, lookLerpSpeed = 3, moveLerpSpeed = 3;

    Vector2 movementInput;
    Vector3 movementDirection;
    Vector3 LookPoint;
    Vector3 CarMovePoint;

    float score = 0;
    int oldScore = 0;
    int scoreModifier = 20;

    // функция для считывания ввода пользователя
    public void DoMovement(InputAction.CallbackContext context){
        movementInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        // прерываем функцию если куб или колеса не были найдены
        if (cube==null) return;
        if (leftWheel==null || rightWheel==null) return;

        // указываем направление движение куба и двигаем его на 1 шаг
        movementDirection = new Vector3(movementInput.x, 0, 0);
        cube.Translate(movementDirection*speed*Time.fixedDeltaTime);

        // поворачиваем колеса
        LookPoint = new Vector3(cube.position.x, transform.position.y, cube.position.z);
        leftWheel.LookAt(LookPoint);
        rightWheel.LookAt(LookPoint);

        // создаем точку, на которую машина будет смотреть
        LookPoint = new Vector3(Mathf.Lerp(transform.position.x,cube.position.x,lookLerpSpeed*Time.fixedDeltaTime), transform.position.y, cube.position.z);
        transform.LookAt(LookPoint);

        // сдвигаем машину в сторону куба 
        CarMovePoint = new Vector3(cube.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, CarMovePoint, moveLerpSpeed*Time.fixedDeltaTime);

        // ведем подсчёт
        score += Time.fixedDeltaTime * scoreModifier;
        if ((int)score != oldScore){
            oldScore = (int)score;
            OnScoreChange?.Invoke(oldScore);
        }
    }
}
