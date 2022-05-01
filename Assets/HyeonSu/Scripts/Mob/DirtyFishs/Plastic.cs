using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plastic : MonoBehaviour
{
    private bool skillType = false;
    private float skillDelay;
    private void Update()
    {
        #region ¿Øµµ≈∫ »∏¿¸ µÙ∑π¿Ã
        skillDelay += Time.deltaTime;
        if (skillDelay >= 1.5f)
            skillType = true;
        if (skillDelay >= 3.5f)
            skillType = false;
        if (skillDelay >= 7)
            Destroy(gameObject);
        #endregion
        #region ¿Øµµ≈∫ ¿Ãµø
        if (skillType == false)
            transform.position += transform.forward * Time.deltaTime * 5f;
        else if(skillType == true)
        {
            Vector3 dir = GameObject.FindGameObjectWithTag("Player").transform.position - this.transform.position;

            transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 1.7f);
            transform.position += transform.forward * Time.deltaTime * 5f;

            //gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
        }
        #endregion
    }
}
