using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ObjectShaker : MonoBehaviour
{
    public Transform objectToShake;
    public float shakeDuration = 0.25f;
    public float rotateShakeIntensity = 3f;
    public float positionShakeIntensity = 0.1f;
    public float shakeRiseAmount = 0.1f;

    private bool isShaking = false;
    private Quaternion initialRotation;
    private Vector3 initialPosition;

    private Coroutine shakeCoroutine;

    private void OnEnable()
    {
        initialRotation = objectToShake.rotation;
        initialPosition = objectToShake.position;
        Shake();
    }

    private void OnDisable()
    {
        StopShake();
    }

    public void Shake()
    {
        if (!isShaking)
        {
            shakeCoroutine = StartCoroutine(ShakeCoroutine());
        }
    }

    public void StopShake()
    {
        if (isShaking && Application.isPlaying)
        {
            StopCoroutine(shakeCoroutine);
            objectToShake.rotation = initialRotation;
            objectToShake.position = initialPosition;
            isShaking = false;
        }
    }

    private void Update()
    {
        objectToShake.rotation = Quaternion.Lerp(objectToShake.rotation, initialRotation, Time.deltaTime * 5f);
        objectToShake.position = Vector3.Lerp(objectToShake.position, initialPosition, Time.deltaTime * 5f);
    }

    private IEnumerator ShakeCoroutine()
    {
        isShaking = true;

        while (isShaking)
        {
            var elapsedTime = 0f;
            while (elapsedTime < shakeDuration)
            {
                var rotationAmountX = Random.Range(-rotateShakeIntensity, rotateShakeIntensity);
                var rotationAmountY = Random.Range(-rotateShakeIntensity, rotateShakeIntensity);
                var rotationAmountZ = Random.Range(-rotateShakeIntensity, rotateShakeIntensity);
                var positionAmountX = Random.Range(-positionShakeIntensity, positionShakeIntensity);
                var positionAmountY = Random.Range(-positionShakeIntensity, positionShakeIntensity);
                var positionAmountZ = Random.Range(-positionShakeIntensity, positionShakeIntensity);
                var rotation = Quaternion.Euler(rotationAmountX, rotationAmountY, rotationAmountZ);
                var position = new Vector3(positionAmountX, positionAmountY, positionAmountZ);

                var riseAmount = Mathf.Lerp(0f, shakeRiseAmount, elapsedTime / shakeDuration);
                var positionOffset = new Vector3(0f, riseAmount, 0f);


                objectToShake.rotation = rotation * initialRotation;
                objectToShake.position = initialPosition + positionOffset + position;

                elapsedTime += Time.deltaTime;
                yield return new WaitForSeconds(0.02f);
            }


            yield return new WaitForSeconds(2f);
        }
    }
}